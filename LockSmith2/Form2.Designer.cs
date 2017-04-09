namespace LockSmith2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.generateRSA = new System.Windows.Forms.Button();
            this.EncryptBtn = new System.Windows.Forms.Button();
            this.DecryptBtn = new System.Windows.Forms.Button();
            this.endtoendCheck = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PubKeyPathTextBox = new System.Windows.Forms.TextBox();
            this.importPubKey = new System.Windows.Forms.Button();
            this.PriKeyPathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.importPriKey = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioBtnFile = new System.Windows.Forms.RadioButton();
            this.radioBtnText = new System.Windows.Forms.RadioButton();
            this.haveRSAKeyPair = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(68, 31);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(470, 20);
            this.filePathTextBox.TabIndex = 0;
            this.filePathTextBox.TextChanged += new System.EventHandler(this.filePathTextBox_TextChanged);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(544, 31);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browsefiles_Click);
            // 
            // generateRSA
            // 
            this.generateRSA.Location = new System.Drawing.Point(544, 227);
            this.generateRSA.Name = "generateRSA";
            this.generateRSA.Size = new System.Drawing.Size(147, 29);
            this.generateRSA.TabIndex = 2;
            this.generateRSA.Text = "Generate Key Pair";
            this.generateRSA.UseVisualStyleBackColor = true;
            this.generateRSA.Click += new System.EventHandler(this.generateRSA_Click);
            // 
            // EncryptBtn
            // 
            this.EncryptBtn.Location = new System.Drawing.Point(625, 31);
            this.EncryptBtn.Name = "EncryptBtn";
            this.EncryptBtn.Size = new System.Drawing.Size(75, 23);
            this.EncryptBtn.TabIndex = 3;
            this.EncryptBtn.Text = "Encrypt";
            this.EncryptBtn.UseVisualStyleBackColor = true;
            this.EncryptBtn.Click += new System.EventHandler(this.EncryptBtn_Click);
            // 
            // DecryptBtn
            // 
            this.DecryptBtn.Location = new System.Drawing.Point(706, 31);
            this.DecryptBtn.Name = "DecryptBtn";
            this.DecryptBtn.Size = new System.Drawing.Size(75, 23);
            this.DecryptBtn.TabIndex = 4;
            this.DecryptBtn.Text = "Decrypt";
            this.DecryptBtn.UseVisualStyleBackColor = true;
            this.DecryptBtn.Click += new System.EventHandler(this.DecryptBtn_Click);
            // 
            // endtoendCheck
            // 
            this.endtoendCheck.AutoSize = true;
            this.endtoendCheck.Location = new System.Drawing.Point(787, 37);
            this.endtoendCheck.Name = "endtoendCheck";
            this.endtoendCheck.Size = new System.Drawing.Size(79, 17);
            this.endtoendCheck.TabIndex = 5;
            this.endtoendCheck.Text = "End-to-End";
            this.endtoendCheck.UseVisualStyleBackColor = true;
            this.endtoendCheck.CheckedChanged += new System.EventHandler(this.endtoendCheck_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(4, 117);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(534, 287);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "File:";
            // 
            // PubKeyPathTextBox
            // 
            this.PubKeyPathTextBox.Enabled = false;
            this.PubKeyPathTextBox.Location = new System.Drawing.Point(68, 60);
            this.PubKeyPathTextBox.Name = "PubKeyPathTextBox";
            this.PubKeyPathTextBox.Size = new System.Drawing.Size(470, 20);
            this.PubKeyPathTextBox.TabIndex = 10;
            this.PubKeyPathTextBox.TextChanged += new System.EventHandler(this.PubKeyPathTextBox_TextChanged);
            // 
            // importPubKey
            // 
            this.importPubKey.Location = new System.Drawing.Point(545, 56);
            this.importPubKey.Name = "importPubKey";
            this.importPubKey.Size = new System.Drawing.Size(155, 23);
            this.importPubKey.TabIndex = 11;
            this.importPubKey.Text = "Browse and Import";
            this.importPubKey.UseVisualStyleBackColor = true;
            this.importPubKey.Click += new System.EventHandler(this.importPubKey_Click);
            // 
            // PriKeyPathTextBox
            // 
            this.PriKeyPathTextBox.Enabled = false;
            this.PriKeyPathTextBox.Location = new System.Drawing.Point(68, 87);
            this.PriKeyPathTextBox.Name = "PriKeyPathTextBox";
            this.PriKeyPathTextBox.Size = new System.Drawing.Size(470, 20);
            this.PriKeyPathTextBox.TabIndex = 13;
            this.PriKeyPathTextBox.TextChanged += new System.EventHandler(this.PriKeyPathTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Public Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Private Key:";
            // 
            // importPriKey
            // 
            this.importPriKey.Location = new System.Drawing.Point(545, 83);
            this.importPriKey.Name = "importPriKey";
            this.importPriKey.Size = new System.Drawing.Size(155, 23);
            this.importPriKey.TabIndex = 16;
            this.importPriKey.Text = "Browse and Import";
            this.importPriKey.UseVisualStyleBackColor = true;
            this.importPriKey.Click += new System.EventHandler(this.importPriKey_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "What is the thing you want to encrypt?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(544, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Do you have an RSA Public/Private Key Pair?";
            // 
            // radioBtnFile
            // 
            this.radioBtnFile.AutoSize = true;
            this.radioBtnFile.Checked = true;
            this.radioBtnFile.Location = new System.Drawing.Point(545, 133);
            this.radioBtnFile.Name = "radioBtnFile";
            this.radioBtnFile.Size = new System.Drawing.Size(51, 17);
            this.radioBtnFile.TabIndex = 7;
            this.radioBtnFile.TabStop = true;
            this.radioBtnFile.Text = "A File";
            this.radioBtnFile.UseVisualStyleBackColor = true;
            this.radioBtnFile.CheckedChanged += new System.EventHandler(this.radioBtnFile_CheckedChanged);
            // 
            // radioBtnText
            // 
            this.radioBtnText.AutoSize = true;
            this.radioBtnText.Location = new System.Drawing.Point(545, 156);
            this.radioBtnText.Name = "radioBtnText";
            this.radioBtnText.Size = new System.Drawing.Size(292, 17);
            this.radioBtnText.TabIndex = 8;
            this.radioBtnText.TabStop = true;
            this.radioBtnText.Text = "I type my message here (Not more than 2000 characters)";
            this.radioBtnText.UseVisualStyleBackColor = true;
            this.radioBtnText.CheckedChanged += new System.EventHandler(this.radioBtnText_CheckedChanged);
            // 
            // haveRSAKeyPair
            // 
            this.haveRSAKeyPair.AutoSize = true;
            this.haveRSAKeyPair.Location = new System.Drawing.Point(547, 197);
            this.haveRSAKeyPair.Name = "haveRSAKeyPair";
            this.haveRSAKeyPair.Size = new System.Drawing.Size(44, 17);
            this.haveRSAKeyPair.TabIndex = 20;
            this.haveRSAKeyPair.Text = "Yes";
            this.haveRSAKeyPair.UseVisualStyleBackColor = true;
            this.haveRSAKeyPair.CheckedChanged += new System.EventHandler(this.haveRSAKeyPair_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 416);
            this.Controls.Add(this.haveRSAKeyPair);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.importPriKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PriKeyPathTextBox);
            this.Controls.Add(this.importPubKey);
            this.Controls.Add(this.PubKeyPathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioBtnText);
            this.Controls.Add(this.radioBtnFile);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.endtoendCheck);
            this.Controls.Add(this.DecryptBtn);
            this.Controls.Add(this.EncryptBtn);
            this.Controls.Add(this.generateRSA);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.filePathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "LockSmith";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button generateRSA;
        private System.Windows.Forms.Button EncryptBtn;
        private System.Windows.Forms.Button DecryptBtn;
        private System.Windows.Forms.CheckBox endtoendCheck;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PubKeyPathTextBox;
        private System.Windows.Forms.Button importPubKey;
        private System.Windows.Forms.TextBox PriKeyPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button importPriKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioBtnFile;
        private System.Windows.Forms.RadioButton radioBtnText;
        private System.Windows.Forms.CheckBox haveRSAKeyPair;
    }
}