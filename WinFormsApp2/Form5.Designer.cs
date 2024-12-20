﻿namespace WinFormsApp2
{
    partial class Form5
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
            buttonSaveImage = new Button();
            labelDecryptionTime = new Label();
            buttonDecrypt = new Button();
            buttonUploadKey_Click = new Button();
            textBoxSpritzKey = new TextBox();
            pictureBoxCipherImage = new PictureBox();
            buttonChooseImage_Click = new Button();
            textBoxCipherImagePath = new TextBox();
            label1 = new Label();
            lblDecryptionTime2 = new Label();
            btnDecryptKey = new Button();
            btnLoadPrivateKey = new Button();
            btnLoadCipherKey = new Button();
            txtPrivateKey = new TextBox();
            txtCipherKey = new TextBox();
            button4 = new Button();
            groupBox1 = new GroupBox();
            groupBox5 = new GroupBox();
            progressBarDecryption2 = new ProgressBar();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            pictureBoxPlainImage = new PictureBox();
            groupBox4 = new GroupBox();
            buttonResetKey2 = new Button();
            labelStatus2 = new Label();
            groupBox6 = new GroupBox();
            progressBarDecryption = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCipherImage).BeginInit();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlainImage).BeginInit();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSaveImage
            // 
            buttonSaveImage.BackColor = Color.FromArgb(5, 183, 171);
            buttonSaveImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSaveImage.ForeColor = SystemColors.ButtonHighlight;
            buttonSaveImage.Location = new Point(512, 315);
            buttonSaveImage.Name = "buttonSaveImage";
            buttonSaveImage.Size = new Size(455, 46);
            buttonSaveImage.TabIndex = 43;
            buttonSaveImage.Text = "Save Citra Medis";
            buttonSaveImage.UseVisualStyleBackColor = false;
            buttonSaveImage.Click += button8_Click;
            // 
            // labelDecryptionTime
            // 
            labelDecryptionTime.AutoSize = true;
            labelDecryptionTime.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDecryptionTime.Location = new Point(520, 261);
            labelDecryptionTime.Name = "labelDecryptionTime";
            labelDecryptionTime.Size = new Size(104, 19);
            labelDecryptionTime.TabIndex = 34;
            labelDecryptionTime.Text = "Waktu Dekripsi:";
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.BackColor = Color.FromArgb(6, 52, 72);
            buttonDecrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDecrypt.ForeColor = SystemColors.Control;
            buttonDecrypt.Location = new Point(520, 95);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(144, 88);
            buttonDecrypt.TabIndex = 33;
            buttonDecrypt.Text = "Decrypt Cipher Image";
            buttonDecrypt.UseVisualStyleBackColor = false;
            buttonDecrypt.Click += buttonDecrypt_Click;
            // 
            // buttonUploadKey_Click
            // 
            buttonUploadKey_Click.BackColor = Color.FromArgb(204, 220, 36);
            buttonUploadKey_Click.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonUploadKey_Click.ForeColor = Color.FromArgb(6, 52, 72);
            buttonUploadKey_Click.Location = new Point(670, 132);
            buttonUploadKey_Click.Name = "buttonUploadKey_Click";
            buttonUploadKey_Click.Size = new Size(174, 51);
            buttonUploadKey_Click.TabIndex = 32;
            buttonUploadKey_Click.Text = "Upload Spritz Key";
            buttonUploadKey_Click.UseVisualStyleBackColor = false;
            buttonUploadKey_Click.Click += buttonUploadKey_Click_Click;
            // 
            // textBoxSpritzKey
            // 
            textBoxSpritzKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSpritzKey.Location = new Point(670, 95);
            textBoxSpritzKey.Name = "textBoxSpritzKey";
            textBoxSpritzKey.Size = new Size(297, 31);
            textBoxSpritzKey.TabIndex = 31;
            // 
            // pictureBoxCipherImage
            // 
            pictureBoxCipherImage.Location = new Point(13, 28);
            pictureBoxCipherImage.Name = "pictureBoxCipherImage";
            pictureBoxCipherImage.Size = new Size(216, 239);
            pictureBoxCipherImage.TabIndex = 27;
            pictureBoxCipherImage.TabStop = false;
            // 
            // buttonChooseImage_Click
            // 
            buttonChooseImage_Click.BackColor = Color.FromArgb(5, 183, 171);
            buttonChooseImage_Click.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonChooseImage_Click.ForeColor = SystemColors.Control;
            buttonChooseImage_Click.Location = new Point(512, 26);
            buttonChooseImage_Click.Name = "buttonChooseImage_Click";
            buttonChooseImage_Click.Size = new Size(455, 42);
            buttonChooseImage_Click.TabIndex = 25;
            buttonChooseImage_Click.Text = "Choose Cipher Image";
            buttonChooseImage_Click.UseVisualStyleBackColor = false;
            buttonChooseImage_Click.Click += buttonChooseImage_Click_Click;
            // 
            // textBoxCipherImagePath
            // 
            textBoxCipherImagePath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCipherImagePath.Location = new Point(11, 32);
            textBoxCipherImagePath.Name = "textBoxCipherImagePath";
            textBoxCipherImagePath.Size = new Size(489, 31);
            textBoxCipherImagePath.TabIndex = 24;
            textBoxCipherImagePath.TextChanged += textBoxCipherImagePath_TextChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(136, 20);
            label1.Name = "label1";
            label1.Size = new Size(757, 37);
            label1.TabIndex = 23;
            label1.Text = "Halaman Dekripsi Cipher Key dan Cipher Image";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDecryptionTime2
            // 
            lblDecryptionTime2.AutoSize = true;
            lblDecryptionTime2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDecryptionTime2.Location = new Point(517, 88);
            lblDecryptionTime2.Name = "lblDecryptionTime2";
            lblDecryptionTime2.Size = new Size(104, 19);
            lblDecryptionTime2.TabIndex = 51;
            lblDecryptionTime2.Text = "Waktu Dekripsi:";
            // 
            // btnDecryptKey
            // 
            btnDecryptKey.BackColor = Color.FromArgb(6, 52, 72);
            btnDecryptKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDecryptKey.ForeColor = SystemColors.Control;
            btnDecryptKey.Location = new Point(395, 38);
            btnDecryptKey.Name = "btnDecryptKey";
            btnDecryptKey.Size = new Size(105, 76);
            btnDecryptKey.TabIndex = 50;
            btnDecryptKey.Text = "Decrypt";
            btnDecryptKey.UseVisualStyleBackColor = false;
            btnDecryptKey.Click += btnDecryptKey_Click;
            // 
            // btnLoadPrivateKey
            // 
            btnLoadPrivateKey.BackColor = Color.FromArgb(19, 123, 110);
            btnLoadPrivateKey.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadPrivateKey.ForeColor = SystemColors.ControlLightLight;
            btnLoadPrivateKey.Location = new Point(296, 153);
            btnLoadPrivateKey.Name = "btnLoadPrivateKey";
            btnLoadPrivateKey.Size = new Size(124, 34);
            btnLoadPrivateKey.TabIndex = 49;
            btnLoadPrivateKey.Text = "Private Key";
            btnLoadPrivateKey.UseVisualStyleBackColor = false;
            btnLoadPrivateKey.Click += btnLoadPrivateKey_Click;
            // 
            // btnLoadCipherKey
            // 
            btnLoadCipherKey.BackColor = Color.FromArgb(204, 220, 36);
            btnLoadCipherKey.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadCipherKey.ForeColor = Color.FromArgb(6, 52, 72);
            btnLoadCipherKey.Location = new Point(296, 111);
            btnLoadCipherKey.Name = "btnLoadCipherKey";
            btnLoadCipherKey.Size = new Size(124, 34);
            btnLoadCipherKey.TabIndex = 48;
            btnLoadCipherKey.Text = "Cipher Key";
            btnLoadCipherKey.UseVisualStyleBackColor = false;
            btnLoadCipherKey.Click += btnLoadCipherKey_Click;
            // 
            // txtPrivateKey
            // 
            txtPrivateKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrivateKey.Location = new Point(40, 153);
            txtPrivateKey.Name = "txtPrivateKey";
            txtPrivateKey.Size = new Size(250, 31);
            txtPrivateKey.TabIndex = 47;
            // 
            // txtCipherKey
            // 
            txtCipherKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCipherKey.Location = new Point(40, 111);
            txtCipherKey.Name = "txtCipherKey";
            txtCipherKey.Size = new Size(250, 31);
            txtCipherKey.TabIndex = 46;
            // 
            // button4
            // 
            button4.Location = new Point(899, 615);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 53;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(btnDecryptKey);
            groupBox1.Controls.Add(lblDecryptionTime2);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(29, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(982, 123);
            groupBox1.TabIndex = 54;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dekripsi Cipher Key";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(progressBarDecryption2);
            groupBox5.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(512, 16);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(455, 63);
            groupBox5.TabIndex = 51;
            groupBox5.TabStop = false;
            groupBox5.Text = "Progress Dekripsi Kunci";
            // 
            // progressBarDecryption2
            // 
            progressBarDecryption2.ForeColor = Color.Plum;
            progressBarDecryption2.Location = new Point(8, 28);
            progressBarDecryption2.Name = "progressBarDecryption2";
            progressBarDecryption2.Size = new Size(441, 26);
            progressBarDecryption2.TabIndex = 45;
            progressBarDecryption2.UseWaitCursor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBoxCipherImage);
            groupBox2.Location = new Point(6, 84);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(243, 277);
            groupBox2.TabIndex = 55;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cipher Image";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pictureBoxPlainImage);
            groupBox3.Location = new Point(257, 84);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(243, 277);
            groupBox3.TabIndex = 56;
            groupBox3.TabStop = false;
            groupBox3.Text = "Plain Image";
            // 
            // pictureBoxPlainImage
            // 
            pictureBoxPlainImage.Location = new Point(14, 28);
            pictureBoxPlainImage.Name = "pictureBoxPlainImage";
            pictureBoxPlainImage.Size = new Size(216, 239);
            pictureBoxPlainImage.TabIndex = 28;
            pictureBoxPlainImage.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(buttonResetKey2);
            groupBox4.Controls.Add(labelStatus2);
            groupBox4.Controls.Add(groupBox6);
            groupBox4.Controls.Add(groupBox3);
            groupBox4.Controls.Add(groupBox2);
            groupBox4.Controls.Add(textBoxCipherImagePath);
            groupBox4.Controls.Add(buttonChooseImage_Click);
            groupBox4.Controls.Add(labelDecryptionTime);
            groupBox4.Controls.Add(buttonUploadKey_Click);
            groupBox4.Controls.Add(buttonDecrypt);
            groupBox4.Controls.Add(textBoxSpritzKey);
            groupBox4.Controls.Add(buttonSaveImage);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(29, 203);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(982, 393);
            groupBox4.TabIndex = 57;
            groupBox4.TabStop = false;
            groupBox4.Text = "Dekripsi Cipher Image";
            groupBox4.Enter += groupBox4_Enter;
            // 
            // buttonResetKey2
            // 
            buttonResetKey2.BackColor = Color.FromArgb(189, 33, 48);
            buttonResetKey2.ForeColor = SystemColors.ControlLightLight;
            buttonResetKey2.Location = new Point(851, 132);
            buttonResetKey2.Name = "buttonResetKey2";
            buttonResetKey2.Size = new Size(116, 51);
            buttonResetKey2.TabIndex = 59;
            buttonResetKey2.Text = "Reset Key";
            buttonResetKey2.UseVisualStyleBackColor = false;
            buttonResetKey2.Click += buttonResetKey2_Click_1;
            // 
            // labelStatus2
            // 
            labelStatus2.AutoSize = true;
            labelStatus2.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus2.Location = new Point(18, 365);
            labelStatus2.Name = "labelStatus2";
            labelStatus2.Size = new Size(85, 19);
            labelStatus2.TabIndex = 58;
            labelStatus2.Text = "Status Citra:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(progressBarDecryption);
            groupBox6.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox6.Location = new Point(512, 189);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(455, 69);
            groupBox6.TabIndex = 57;
            groupBox6.TabStop = false;
            groupBox6.Text = "Progress Dekripsi Citra";
            // 
            // progressBarDecryption
            // 
            progressBarDecryption.ForeColor = Color.Plum;
            progressBarDecryption.Location = new Point(8, 28);
            progressBarDecryption.Name = "progressBarDecryption";
            progressBarDecryption.Size = new Size(441, 27);
            progressBarDecryption.TabIndex = 44;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 247, 255);
            ClientSize = new Size(1038, 669);
            Controls.Add(button4);
            Controls.Add(btnLoadPrivateKey);
            Controls.Add(btnLoadCipherKey);
            Controls.Add(txtPrivateKey);
            Controls.Add(txtCipherKey);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman Dekripsi";
            Load += Form5_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCipherImage).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlainImage).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSaveImage;
        private Label labelDecryptionTime;
        private Button buttonDecrypt;
        private Button buttonUploadKey_Click;
        private TextBox textBoxSpritzKey;
        private PictureBox pictureBoxCipherImage;
        private Button buttonChooseImage_Click;
        private TextBox textBoxCipherImagePath;
        private Label label1;
        private Label lblDecryptionTime2;
        private Button btnDecryptKey;
        private Button btnLoadPrivateKey;
        private Button btnLoadCipherKey;
        private TextBox txtPrivateKey;
        private TextBox txtCipherKey;
        private Button button4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ProgressBar progressBarDecryption2;
        private PictureBox pictureBoxPlainImage;
        private ProgressBar progressBarDecryption;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label labelStatus2;
        private Button buttonResetKey2;
    }
}