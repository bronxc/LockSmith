using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
//using System.Diagnostics;
using cryptokey;


namespace LockSmith2
{
    public partial class Form2 : Form
    {
        string workingPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Lock\";
        string msgPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "msg.txt";

        public Form2()
        {
            InitializeComponent();
            Directory.CreateDirectory(workingPath);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void browsefiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void generateRSA_Click(object sender, EventArgs e)
        {
            handlekeys keypair = new handlekeys();
            keypair.GenerateKeyPair();
            MessageBox.Show("RSA Key Pair generated and exported to ~Desktop\\Lock\\ Directory. Keep it safe!","Heads Up!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if(filePathTextBox.Text.Length > 200)
            {
                EncryptBtn.Enabled = false;
                DecryptBtn.Enabled = false;
            }
            else
            {
                EncryptBtn.Enabled = true;
                DecryptBtn.Enabled = true;
            }
        }

        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            if (radioBtnText.Checked)
            {
                //checking for text
                if (richTextBox1.Text.Length == 0 || richTextBox1.Text.Length > 2000)
                {
                    MessageBox.Show("More than 0, less than 2000! Okay?", "Off The limits!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                    File.WriteAllText(msgPath, richTextBox1.Text);
                    string cleartext = msgPath;

                    handlekeys Box = new handlekeys();

                    //checking for End-to-End
                    if (endtoendCheck.Checked)
                    {
                        if (haveRSAKeyPair.Checked)
                        {
                            FileInfo pubkeyinfo = new FileInfo(PubKeyPathTextBox.Text);
                            if (pubkeyinfo.Length > 415)
                            {
                                MessageBox.Show("Public key file bigger than usual. Are you trying to trick me?", "Invalid Public Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if(pubkeyinfo.Length < 415)
                            {
                                MessageBox.Show("Public key file smaller than usual. Are you trying to trick me?", "Invalid Public Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                Box.AesEncrypt(cleartext, true, PubKeyPathTextBox.Text);
                            }
                        }
                        else
                        {
                            Box.AesEncrypt(cleartext, true);
                        }
                        
                    }
                    else
                    {

                        Box.AesEncrypt(cleartext, false);
                    }
                }
            }
            else
            {
                //checking arguments
                if (filePathTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please Specify a file!", "No file specified", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else if (filePathTextBox.Text.Length >= 260)
                {
                    MessageBox.Show("Path is too long! Keep it short ;)", "Path too long",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    FileInfo filetoencrypt = new FileInfo(filePathTextBox.Text);
                    if (filetoencrypt.Length > 10000000)
                    {
                        MessageBox.Show("File too big!", "Big File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(filetoencrypt.Length <= 8)
                    {
                        MessageBox.Show("File too Small!", "Small File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string unEnc = filePathTextBox.Text;
                        handlekeys Box = new handlekeys();

                        //checking for End-to-End
                        if (endtoendCheck.Checked == true)
                        {
                            if (haveRSAKeyPair.Checked)
                            {
                                Box.AesEncrypt(unEnc, true, PubKeyPathTextBox.Text);
                            }
                            else
                            {
                                Box.AesEncrypt(unEnc, true);
                            }
                        }
                        else
                        {
                            Box.AesEncrypt(unEnc, false);
                        }
                    }
                }
            }
        }

        private void DecryptBtn_Click(object sender, EventArgs e)
        {
            string cipherfile = filePathTextBox.Text;
            handlekeys unBox = new handlekeys();
            if (endtoendCheck.Checked == true)
            {
                if (haveRSAKeyPair.Checked)
                {
                    FileInfo prikeyinfo = new FileInfo(PriKeyPathTextBox.Text);
                    if (prikeyinfo.Length > 1679)
                    {
                        MessageBox.Show("Private key file bigger than usual. Are you trying to trick me?", "Invalid Private Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (prikeyinfo.Length < 1679)
                    {
                        MessageBox.Show("Private key file smaller than usual. Are you trying to trick me?", "Invalid Private Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        unBox.AesDecrypt(cipherfile, true, PriKeyPathTextBox.Text);
                    }
                    
                }
                
            }
            else
            {
                unBox.AesDecrypt(cipherfile, false, null);
            }
            
        }

        private void radioBtnText_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnText.Checked == true)
            {
                filePathTextBox.Enabled = false;
                filePathTextBox.ReadOnly = true;
                richTextBox1.Enabled = true;
            }
            else
            {
                filePathTextBox.Enabled = true;
                filePathTextBox.ReadOnly = false;
                richTextBox1.Enabled = false;
            }
        }

        private void endtoendCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(endtoendCheck.Checked == false)
            {
                haveRSAKeyPair.IsAccessible = false;
            }
            else
            {
                haveRSAKeyPair.IsAccessible = true;
            }
        }

        private void importPubKey_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PubKeyPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void importPriKey_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PriKeyPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void haveRSAKeyPair_CheckedChanged(object sender, EventArgs e)
        {
            if (haveRSAKeyPair.Checked == false)
            {
                PubKeyPathTextBox.ReadOnly = true;
                PubKeyPathTextBox.Enabled = false;

                PriKeyPathTextBox.ReadOnly = true;
                PriKeyPathTextBox.Enabled = false;
            }
            else
            {
                PubKeyPathTextBox.ReadOnly = false;
                PubKeyPathTextBox.Enabled = true;

                PriKeyPathTextBox.ReadOnly = false;
                PriKeyPathTextBox.Enabled = true;
            }
        }

        private void radioBtnFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PubKeyPathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PubKeyPathTextBox.Text.Length > 300)
            {
                EncryptBtn.Enabled = false;
                DecryptBtn.Enabled = false;
            }
            else
            {
                EncryptBtn.Enabled = true;
                DecryptBtn.Enabled = true;
            }
        }

        private void PriKeyPathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PriKeyPathTextBox.Text.Length > 300)
            {
                EncryptBtn.Enabled = false;
                DecryptBtn.Enabled = false;
            }
            else
            {
                EncryptBtn.Enabled = true;
                DecryptBtn.Enabled = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Length > 2000)
            {
                EncryptBtn.Enabled = false;
                DecryptBtn.Enabled = false;
            }
            else
            {
                EncryptBtn.Enabled = true;
                DecryptBtn.Enabled = true;
            }
        }
    }
}