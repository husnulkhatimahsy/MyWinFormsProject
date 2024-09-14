namespace WinFormsApp2
{
    partial class Form4
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
            label1 = new Label();
            textBoxImagePath = new TextBox();
            button1chooseimage = new Button();
            pictureBoxSelectedImage = new PictureBox();
            pictureBoxEncrypted = new PictureBox();
            textBoxSpritzKey = new TextBox();
            button2 = new Button();
            button3 = new Button();
            labelEncryptionTime = new Label();
            button4 = new Button();
            textBoxSpritzKey2 = new TextBox();
            textBoxRsaPublicKey = new TextBox();
            buttonLoadSpritzKey = new Button();
            buttonRsaPublicKey = new Button();
            buttonEncryptSpritzKey = new Button();
            labelEncryptionTime2 = new Label();
            button8 = new Button();
            buttonSaveCipherKey = new Button();
            button10 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            progressBarEncryption = new ProgressBar();
            groupBox4 = new GroupBox();
            progressBarEncryption2 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEncrypted).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(109, 16);
            label1.Name = "label1";
            label1.Size = new Size(757, 50);
            label1.TabIndex = 1;
            label1.Text = "Halaman Enkripsi Citra Medis dan Kunci Spritz";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // textBoxImagePath
            // 
            textBoxImagePath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxImagePath.Location = new Point(12, 33);
            textBoxImagePath.Name = "textBoxImagePath";
            textBoxImagePath.Size = new Size(479, 31);
            textBoxImagePath.TabIndex = 2;
            // 
            // button1chooseimage
            // 
            button1chooseimage.BackColor = Color.FromArgb(5, 183, 171);
            button1chooseimage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1chooseimage.ForeColor = SystemColors.Control;
            button1chooseimage.Location = new Point(502, 30);
            button1chooseimage.Name = "button1chooseimage";
            button1chooseimage.Size = new Size(379, 37);
            button1chooseimage.TabIndex = 3;
            button1chooseimage.Text = "Choose Image";
            button1chooseimage.UseVisualStyleBackColor = false;
            button1chooseimage.Click += button1_Click;
            // 
            // pictureBoxSelectedImage
            // 
            pictureBoxSelectedImage.Location = new Point(8, 32);
            pictureBoxSelectedImage.Name = "pictureBoxSelectedImage";
            pictureBoxSelectedImage.Size = new Size(216, 216);
            pictureBoxSelectedImage.TabIndex = 5;
            pictureBoxSelectedImage.TabStop = false;
            // 
            // pictureBoxEncrypted
            // 
            pictureBoxEncrypted.Location = new Point(9, 30);
            pictureBoxEncrypted.Name = "pictureBoxEncrypted";
            pictureBoxEncrypted.Size = new Size(216, 216);
            pictureBoxEncrypted.TabIndex = 6;
            pictureBoxEncrypted.TabStop = false;
            // 
            // textBoxSpritzKey
            // 
            textBoxSpritzKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSpritzKey.Location = new Point(657, 117);
            textBoxSpritzKey.Name = "textBoxSpritzKey";
            textBoxSpritzKey.Size = new Size(224, 31);
            textBoxSpritzKey.TabIndex = 9;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(204, 220, 36);
            button2.ForeColor = Color.FromArgb(6, 52, 72);
            button2.Location = new Point(502, 117);
            button2.Name = "button2";
            button2.Size = new Size(132, 71);
            button2.TabIndex = 10;
            button2.Text = "Generate Spritz Key";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(6, 52, 72);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(778, 154);
            button3.Name = "button3";
            button3.Size = new Size(103, 34);
            button3.TabIndex = 11;
            button3.Text = "Encrypt";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // labelEncryptionTime
            // 
            labelEncryptionTime.AutoSize = true;
            labelEncryptionTime.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEncryptionTime.Location = new Point(502, 208);
            labelEncryptionTime.Name = "labelEncryptionTime";
            labelEncryptionTime.Size = new Size(132, 25);
            labelEncryptionTime.TabIndex = 12;
            labelEncryptionTime.Text = "Waktu Enkripsi:";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(19, 123, 110);
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Location = new Point(657, 154);
            button4.Name = "button4";
            button4.Size = new Size(103, 34);
            button4.TabIndex = 13;
            button4.Text = "Save Key";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBoxSpritzKey2
            // 
            textBoxSpritzKey2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSpritzKey2.Location = new Point(11, 40);
            textBoxSpritzKey2.Name = "textBoxSpritzKey2";
            textBoxSpritzKey2.Size = new Size(235, 31);
            textBoxSpritzKey2.TabIndex = 15;
            // 
            // textBoxRsaPublicKey
            // 
            textBoxRsaPublicKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxRsaPublicKey.Location = new Point(11, 82);
            textBoxRsaPublicKey.Name = "textBoxRsaPublicKey";
            textBoxRsaPublicKey.Size = new Size(235, 31);
            textBoxRsaPublicKey.TabIndex = 16;
            // 
            // buttonLoadSpritzKey
            // 
            buttonLoadSpritzKey.BackColor = Color.FromArgb(204, 220, 36);
            buttonLoadSpritzKey.ForeColor = Color.FromArgb(6, 52, 72);
            buttonLoadSpritzKey.Location = new Point(262, 40);
            buttonLoadSpritzKey.Name = "buttonLoadSpritzKey";
            buttonLoadSpritzKey.Size = new Size(124, 34);
            buttonLoadSpritzKey.TabIndex = 17;
            buttonLoadSpritzKey.Text = "Kunci Spritz";
            buttonLoadSpritzKey.UseVisualStyleBackColor = false;
            buttonLoadSpritzKey.Click += buttonLoadSpritzKey_Click;
            // 
            // buttonRsaPublicKey
            // 
            buttonRsaPublicKey.BackColor = Color.FromArgb(19, 123, 110);
            buttonRsaPublicKey.ForeColor = SystemColors.ControlLightLight;
            buttonRsaPublicKey.Location = new Point(262, 81);
            buttonRsaPublicKey.Name = "buttonRsaPublicKey";
            buttonRsaPublicKey.Size = new Size(124, 34);
            buttonRsaPublicKey.TabIndex = 18;
            buttonRsaPublicKey.Text = "Public Key";
            buttonRsaPublicKey.UseVisualStyleBackColor = false;
            buttonRsaPublicKey.Click += buttonRsaPublicKey_Click;
            // 
            // buttonEncryptSpritzKey
            // 
            buttonEncryptSpritzKey.BackColor = Color.FromArgb(6, 52, 72);
            buttonEncryptSpritzKey.ForeColor = SystemColors.Control;
            buttonEncryptSpritzKey.Location = new Point(392, 40);
            buttonEncryptSpritzKey.Name = "buttonEncryptSpritzKey";
            buttonEncryptSpritzKey.Size = new Size(99, 76);
            buttonEncryptSpritzKey.TabIndex = 19;
            buttonEncryptSpritzKey.Text = "Encrypt";
            buttonEncryptSpritzKey.UseVisualStyleBackColor = false;
            buttonEncryptSpritzKey.Click += buttonEncryptSpritzKey_Click;
            // 
            // labelEncryptionTime2
            // 
            labelEncryptionTime2.AutoSize = true;
            labelEncryptionTime2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEncryptionTime2.Location = new Point(501, 18);
            labelEncryptionTime2.Name = "labelEncryptionTime2";
            labelEncryptionTime2.Size = new Size(132, 25);
            labelEncryptionTime2.TabIndex = 20;
            labelEncryptionTime2.Text = "Waktu Enkripsi:";
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(5, 183, 171);
            button8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = SystemColors.ButtonHighlight;
            button8.Location = new Point(502, 277);
            button8.Name = "button8";
            button8.Size = new Size(379, 56);
            button8.TabIndex = 21;
            button8.Text = "Save Cipher Image";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // buttonSaveCipherKey
            // 
            buttonSaveCipherKey.BackColor = Color.FromArgb(5, 183, 171);
            buttonSaveCipherKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSaveCipherKey.ForeColor = SystemColors.Control;
            buttonSaveCipherKey.Location = new Point(502, 73);
            buttonSaveCipherKey.Name = "buttonSaveCipherKey";
            buttonSaveCipherKey.Size = new Size(379, 42);
            buttonSaveCipherKey.TabIndex = 22;
            buttonSaveCipherKey.Text = "Save Cipher Key";
            buttonSaveCipherKey.UseVisualStyleBackColor = false;
            buttonSaveCipherKey.Click += buttonSaveCipherKey_Click;
            // 
            // button10
            // 
            button10.Location = new Point(806, 558);
            button10.Name = "button10";
            button10.Size = new Size(112, 34);
            button10.TabIndex = 23;
            button10.Text = "Back";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBoxSelectedImage);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 85);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(232, 259);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Plain Image";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBoxEncrypted);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(254, 85);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(237, 259);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cipher Image";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(progressBarEncryption);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(groupBox1);
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(labelEncryptionTime);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(textBoxSpritzKey);
            groupBox3.Controls.Add(button1chooseimage);
            groupBox3.Controls.Add(textBoxImagePath);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(37, 57);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(892, 355);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Enkripsi Citra Medis";
            // 
            // progressBarEncryption
            // 
            progressBarEncryption.ForeColor = Color.Plum;
            progressBarEncryption.Location = new Point(504, 247);
            progressBarEncryption.Name = "progressBarEncryption";
            progressBarEncryption.Size = new Size(376, 26);
            progressBarEncryption.TabIndex = 26;
            progressBarEncryption.UseWaitCursor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(progressBarEncryption2);
            groupBox4.Controls.Add(buttonSaveCipherKey);
            groupBox4.Controls.Add(labelEncryptionTime2);
            groupBox4.Controls.Add(buttonEncryptSpritzKey);
            groupBox4.Controls.Add(buttonRsaPublicKey);
            groupBox4.Controls.Add(buttonLoadSpritzKey);
            groupBox4.Controls.Add(textBoxRsaPublicKey);
            groupBox4.Controls.Add(textBoxSpritzKey2);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(37, 420);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(892, 125);
            groupBox4.TabIndex = 27;
            groupBox4.TabStop = false;
            groupBox4.Text = "Enkripsi Kunci Spritz";
            // 
            // progressBarEncryption2
            // 
            progressBarEncryption2.ForeColor = Color.Plum;
            progressBarEncryption2.Location = new Point(505, 48);
            progressBarEncryption2.Name = "progressBarEncryption2";
            progressBarEncryption2.Size = new Size(376, 19);
            progressBarEncryption2.TabIndex = 27;
            progressBarEncryption2.UseWaitCursor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 247, 255);
            ClientSize = new Size(958, 604);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(button10);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman Enkripsi";
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEncrypted).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox textBoxImagePath;
        private Button button1chooseimage;
        private PictureBox pictureBoxSelectedImage;
        private PictureBox pictureBoxEncrypted;
        private TextBox textBoxSpritzKey;
        private Button button2;
        private Button button3;
        private Label labelEncryptionTime;
        private Button button4;
        private TextBox textBoxSpritzKey2;
        private TextBox textBoxRsaPublicKey;
        private Button buttonLoadSpritzKey;
        private Button buttonRsaPublicKey;
        private Button buttonEncryptSpritzKey;
        private Label labelEncryptionTime2;
        private Button button8;
        private Button buttonSaveCipherKey;
        private Button button10;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ProgressBar progressBarEncryption;
        private ProgressBar progressBarEncryption2;
    }
}