﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace cryptokey
{
    public class handlekeys
    {
        // working path
        private string KeyPairPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Lock\";
        private string pathToAes = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Lock\";


        public void GenerateKeyPair()
        {
            // Declare CspParmeters and RsaCryptoServiceProvider
            // objects with global scope of your Form class.
            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = "Key00";
            // Generate RSA key pair and save it to the container
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048, cspp);

            exportRSAkeypair(rsa, KeyPairPath);

        }


        private void exportRSAkeypair(RSACryptoServiceProvider rsa, string path)
        {
            StreamWriter swpub = new StreamWriter(path + "rsaPublicKey.txt", false);
            swpub.Write(rsa.ToXmlString(false));
            swpub.Close();
            StreamWriter swpri = new StreamWriter(path + "rsaPrivateKey.txt", false);
            swpri.Write(rsa.ToXmlString(true));
            swpri.Close();
        }


        private byte[] encryptthekey(byte[] aesKey, string publickey = null)
        {

            //creating a container to import rsa public key
            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = "Key00";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048, cspp);

            //import the RSA public key for encryption
            rsa = importRSAkeypair(rsa, false, publickey);

            //persisting the key in container
            rsa.PersistKeyInCsp = true;

            //encrypting the aes key and vector
            byte[] aesKeyEncrypted = rsa.Encrypt(aesKey, false);

            // Returning the encrypted AES Key
            return aesKeyEncrypted;

        }


        private RSACryptoServiceProvider importRSAkeypair(RSACryptoServiceProvider rsa, bool priavte, string publickey = null, string privatekey = null)
        {
            if (priavte == false)
            {
                string PubKeyFile = null;
                if (publickey == null)
                {
                    PubKeyFile = KeyPairPath + "rsaPublicKey.txt";
                }
                else
                {
                    PubKeyFile = publickey;
                }

                StreamReader srpub = new StreamReader(PubKeyFile);
                string rsapubkeytext = srpub.ReadToEnd();
                srpub.Close();
                
                rsa.FromXmlString(rsapubkeytext);
                return rsa;
            }
            else
            {
                string PriKeyFile = null;
                if (privatekey == null)
                {
                    PriKeyFile = KeyPairPath + "rsaPrivateKey.txt";
                }
                else
                {
                    PriKeyFile = privatekey;
                }
                StreamReader srpri = new StreamReader(PriKeyFile);
                string rsaprikeytext = srpri.ReadToEnd();
                srpri.Close();
                //importing the private key to rsa object
                rsa.FromXmlString(rsaprikeytext);
                return rsa;
            }

        }



        private byte[] decryptthekey(byte[] aesEncryptedKey, string privatekey)
        {
            //creating a container to import rsa public key
            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = "Key01";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048, cspp);

            //import the RSA private key for decryption
            if(privatekey.Length == 0)
            {
                rsa = importRSAkeypair(rsa, true,null,privatekey);
            }
            else
            {
                rsa = importRSAkeypair(rsa, true);
            }

            //no persisting the key in container
            rsa.PersistKeyInCsp = false;

            byte[] aesDecryptedKey = rsa.Decrypt(aesEncryptedKey, false);

            return aesDecryptedKey;
        }



        public void AesEncrypt(string plainfile, bool endtoend, string publickey = null)
        {
            // Create instance of Rijndael for
            // symetric encryption of the data.
            RijndaelManaged myaes = new RijndaelManaged();
            myaes.KeySize = 256;
            myaes.BlockSize = 256;
            myaes.Mode = CipherMode.CBC;
            myaes.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = myaes.CreateEncryptor();


            byte[] keyEncrypted = new byte[4];
            if (endtoend)
            {
                if (publickey != null)
                {
                    keyEncrypted = encryptthekey(myaes.Key, publickey);
                }
                else
                {
                    keyEncrypted = encryptthekey(myaes.Key);
                }
            }


            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            int lKey;
            if (endtoend)
            {
               lKey = keyEncrypted.Length;
            }
            else
            {
                lKey = myaes.IV.Length;
            }
            LenK = BitConverter.GetBytes(lKey);
            int lIV = myaes.IV.Length;
            LenIV = BitConverter.GetBytes(lIV);

            // Write the following to the FileStream
            // for the encrypted file (outFs):
            // - length of the key
            // - length of the IV
            // - ecrypted key
            // - the IV
            // - the encrypted cipher content

            // Change the file's extension to ".enc"

            string outFile1 = plainfile.Substring(0, plainfile.LastIndexOf(".")) + ".enc";
            string outFile2 = Path.Combine(pathToAes, outFile1);
            using (FileStream outFs = new FileStream(outFile2, FileMode.Create))
            {

                outFs.Write(LenK, 0, 4);
                outFs.Write(LenIV, 0, 4);
                if (endtoend)
                {
                    outFs.Write(keyEncrypted, 0, lKey);
                }
                else
                {
                    outFs.Write(myaes.Key, 0, lKey);
                }
                outFs.Write(myaes.IV, 0, lIV);

                // Now write the cipher text using
                // a CryptoStream for encrypting.
                using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                {

                    // By encrypting a chunk at
                    // a time, you can save memory
                    // and accommodate large files.
                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = myaes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];
                    int bytesRead = 0;

                    using (FileStream inFs = new FileStream(plainfile, FileMode.Open))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        }
                        while (count > 0);
                        inFs.Close();
                    }
                    outStreamEncrypted.FlushFinalBlock();
                    outStreamEncrypted.Close();
                }
                outFs.Close();
            }
        }


        public void AesDecrypt(string cipherfile, bool endtoend, string privatekey = null)
        {
            // Create instance of Rijndael for
            // symetric decryption of the data.
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 256;
            rjndl.Mode = CipherMode.CBC;
            rjndl.Padding = PaddingMode.PKCS7;

            // Create byte arrays to get the length of
            // the encrypted key and IV.
            // These values were stored as 4 bytes each
            // at the beginning of the encrypted package.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Consruct the file name for the decrypted file.
            string outFile1 = cipherfile.Substring(0, cipherfile.LastIndexOf(".")) + ".txt";
            string outFile2 = Path.Combine(pathToAes, outFile1);
            string inFile = Path.Combine(pathToAes, cipherfile);

            // Use FileStream objects to read the encrypted
            // file (inFs) and save the decrypted file (outFs).
            using (FileStream inFs = new FileStream(inFile, FileMode.Open))
            {

                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                // Convert the lengths to integer values.
                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Determine the start postition of
                // the ciphter text (startC)
                // and its length(lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;

                // Create the byte arrays for
                // the encrypted Rijndael key,
                // the IV, and the cipher text.
                byte[] KeyEncrypted = new byte[lenK];
                byte[] Key = new byte[lenK];
                byte[] IV = new byte[lenIV];

                // Extract the key and IV
                // starting from index 8
                // after the length values.
                inFs.Seek(8, SeekOrigin.Begin);
                if (endtoend)
                {
                    inFs.Read(KeyEncrypted, 0, lenK);
                }
                else
                {
                    inFs.Read(Key, 0, lenK);
                }
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);

                byte[] KeyDecrypted = new byte[4];
                if (endtoend)
                {
                    // Use RSACryptoServiceProvider
                    // to decrypt the Rijndael key.
                    KeyDecrypted = decryptthekey(KeyEncrypted,privatekey);
                }
                ICryptoTransform transform;
                if (endtoend)
                {
                    transform = rjndl.CreateDecryptor(KeyDecrypted, IV);
                }
                else
                {
                    transform = rjndl.CreateDecryptor(Key, IV);
                }
                
                // Decrypt the cipher text from
                // from the FileSteam of the encrypted
                // file (inFs) into the FileStream
                // for the decrypted file (outFs).
                using (FileStream outFs = new FileStream(outFile2, FileMode.Create))
                {

                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = rjndl.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];


                    // By decrypting a chunk a time,
                    // you can save memory and
                    // accommodate large files.

                    // Start at the beginning
                    // of the cipher text.
                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamDecrypted.Write(data, 0, count);

                        }
                        while (count > 0);

                        outStreamDecrypted.FlushFinalBlock();
                        outStreamDecrypted.Close();
                    }
                    outFs.Close();
                }
                inFs.Close();
            }

        }

    }
}