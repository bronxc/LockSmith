# LockSmith
A Simple Cryptography Windows Application

I'm writing this application in order to remember what I learned when I was 14 joining a local C# programming class and as a school project. I also want to be better in SW development. So, whoever wants to tell me my flaws and teach me how to do programming better, I appreciate him/her a lot!


This appliocation can encrypt "ANY" file format NOW!!!

ENCRYPTION PROCESS without End-to-End feature:
  
  In this method which completely unsafe and not recommended, we specifiy a text file or we can type our message directly in the big textbox inside the application and click on encrypt button. An AES-256 bits Key and an AES Vector will be generated. AES is a symmetric key which will be used for both encryption and decryption. Using the AES key and vector, we encrypt our text file. This process will result in a byte array representing the encrypted file. The first 4 bytes of the file will hold space for the legnth of our AES-256 bit key. The second 4 bytes of the file will be the legnth of AES vector. Then we addd the legnth of our extenton which holds the next 4 bytes. Then we actually write the AES KEY, Vecor and the extension and then the encrypted bytes and save the file with a ".enc" format.

DECRYPTION PROCESS without End-to-End feature:

  We get the file which need to be decrypted (the .enc file). We click on Decrypt. It retrieves the AES-256 bit key, vector and the extension of the file using the information saved in the beginning og the file during encryption. It creates an AES object with the retrieved key and vector, and it decryptes the file and save the decrypted file to disk with the proper extension.
  
  
ENCRYPTION PROCESS with End-to-End feature:

  The only difference that it makes is that in this process, the AES key will be encrypted with an RSA public key first, then written to the file in the same manner as explained above.
  
DECRYPTION PROCESS with End-to-End feature:

  You pretty much got the idea...
  
  
FAQs:

How long is the AES key?

-> 256 bits

How long is the RSA key pair?

-> 2048 bits
What files formats can I encrypt?

-> ANY!!! (version 2.1 =<)

Only XML format of the RSA key pair is usable, right?

-> right! for now :)


Test:
To encrypt
1. Run the program and create a text (.txt) with your desired message in it.
2. Generate your RSA key pair.
3. Give the application the text file to encrypt and your generated public key. (Make sure you check the end-to-end option and also check the box asks you if you have an RSA key pair)
4. Click encrypt. Your encrypted file will be in ~Desktop\Lock\ folder.
To decrypt:
1. give the appliction the encrypted (.enc) file.
2. Give the application the text file to encrypt and your generated private key. (Make sure you check the end-to-end option and also check the box asks you if you have an RSA key pair).
3. Click Decrypt. Your decrypted file will be in ~Desktop\Lock\ folder.
