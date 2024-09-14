namespace WinFormsApp2
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
            btnSaveSpritzKey = new Button();
            lblDecryptionTime2 = new Label();
            btnDecryptKey = new Button();
            btnLoadPrivateKey = new Button();
            btnLoadCipherKey = new Button();
            txtPrivateKey = new TextBox();
            txtCipherKey = new TextBox();
            button4 = new Button();
            groupBox1 = new GroupBox();
            progressBarDecryption2 = new ProgressBar();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            pictureBoxPlainImage = new PictureBox();
            groupBox4 = new GroupBox();
            progressBarDecryption = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCipherImage).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlainImage).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSaveImage
            // 
            buttonSaveImage.BackColor = Color.FromArgb(5, 183, 171);
            buttonSaveImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSaveImage.ForeColor = SystemColors.ButtonHighlight;
            buttonSaveImage.Location = new Point(520, 284);
            buttonSaveImage.Name = "buttonSaveImage";
            buttonSaveImage.Size = new Size(379, 56);
            buttonSaveImage.TabIndex = 43;
            buttonSaveImage.Text = "Save Citra Medis";
            buttonSaveImage.UseVisualStyleBackColor = false;
            buttonSaveImage.Click += button8_Click;
            // 
            // labelDecryptionTime
            // 
            labelDecryptionTime.AutoSize = true;
            labelDecryptionTime.Location = new Point(549, 411);
            labelDecryptionTime.Name = "labelDecryptionTime";
            labelDecryptionTime.Size = new Size(135, 25);
            labelDecryptionTime.TabIndex = 34;
            labelDecryptionTime.Text = "Waktu Dekripsi:";
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.BackColor = Color.FromArgb(6, 52, 72);
            buttonDecrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDecrypt.ForeColor = SystemColors.Control;
            buttonDecrypt.Location = new Point(670, 156);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(229, 45);
            buttonDecrypt.TabIndex = 33;
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.UseVisualStyleBackColor = false;
            buttonDecrypt.Click += buttonDecrypt_Click;
            // 
            // buttonUploadKey_Click
            // 
            buttonUploadKey_Click.BackColor = Color.FromArgb(204, 220, 36);
            buttonUploadKey_Click.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonUploadKey_Click.ForeColor = Color.FromArgb(6, 52, 72);
            buttonUploadKey_Click.Location = new Point(520, 113);
            buttonUploadKey_Click.Name = "buttonUploadKey_Click";
            buttonUploadKey_Click.Size = new Size(132, 88);
            buttonUploadKey_Click.TabIndex = 32;
            buttonUploadKey_Click.Text = "Upload Spritz Key";
            buttonUploadKey_Click.UseVisualStyleBackColor = false;
            buttonUploadKey_Click.Click += buttonUploadKey_Click_Click;
            // 
            // textBoxSpritzKey
            // 
            textBoxSpritzKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSpritzKey.Location = new Point(670, 113);
            textBoxSpritzKey.Name = "textBoxSpritzKey";
            textBoxSpritzKey.Size = new Size(229, 31);
            textBoxSpritzKey.TabIndex = 31;
            // 
            // pictureBoxCipherImage
            // 
            pictureBoxCipherImage.Location = new Point(13, 28);
            pictureBoxCipherImage.Name = "pictureBoxCipherImage";
            pictureBoxCipherImage.Size = new Size(216, 216);
            pictureBoxCipherImage.TabIndex = 27;
            pictureBoxCipherImage.TabStop = false;
            // 
            // buttonChooseImage_Click
            // 
            buttonChooseImage_Click.BackColor = Color.FromArgb(5, 183, 171);
            buttonChooseImage_Click.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonChooseImage_Click.ForeColor = SystemColors.Control;
            buttonChooseImage_Click.Location = new Point(520, 26);
            buttonChooseImage_Click.Name = "buttonChooseImage_Click";
            buttonChooseImage_Click.Size = new Size(379, 42);
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
            textBoxCipherImagePath.Size = new Size(484, 31);
            textBoxCipherImagePath.TabIndex = 24;
            textBoxCipherImagePath.TextChanged += textBoxCipherImagePath_TextChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 18);
            label1.Name = "label1";
            label1.Size = new Size(757, 37);
            label1.TabIndex = 23;
            label1.Text = "Halaman Dekripsi Cipher Key dan Cipher Image";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSaveSpritzKey
            // 
            btnSaveSpritzKey.BackColor = Color.FromArgb(5, 183, 171);
            btnSaveSpritzKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveSpritzKey.ForeColor = SystemColors.Control;
            btnSaveSpritzKey.Location = new Point(549, 149);
            btnSaveSpritzKey.Name = "btnSaveSpritzKey";
            btnSaveSpritzKey.Size = new Size(379, 42);
            btnSaveSpritzKey.TabIndex = 52;
            btnSaveSpritzKey.Text = "Save Kunci Spritz";
            btnSaveSpritzKey.UseVisualStyleBackColor = false;
            btnSaveSpritzKey.Click += btnSaveSpritzKey_Click;
            // 
            // lblDecryptionTime2
            // 
            lblDecryptionTime2.AutoSize = true;
            lblDecryptionTime2.Location = new Point(549, 91);
            lblDecryptionTime2.Name = "lblDecryptionTime2";
            lblDecryptionTime2.Size = new Size(135, 25);
            lblDecryptionTime2.TabIndex = 51;
            lblDecryptionTime2.Text = "Waktu Dekripsi:";
            // 
            // btnDecryptKey
            // 
            btnDecryptKey.BackColor = Color.FromArgb(6, 52, 72);
            btnDecryptKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDecryptKey.ForeColor = SystemColors.Control;
            btnDecryptKey.Location = new Point(390, 38);
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
            btnLoadPrivateKey.Location = new Point(289, 153);
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
            btnLoadCipherKey.Location = new Point(289, 111);
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
            txtPrivateKey.Size = new Size(232, 31);
            txtPrivateKey.TabIndex = 47;
            // 
            // txtCipherKey
            // 
            txtCipherKey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCipherKey.Location = new Point(40, 111);
            txtCipherKey.Name = "txtCipherKey";
            txtCipherKey.Size = new Size(232, 31);
            txtCipherKey.TabIndex = 46;
            // 
            // button4
            // 
            button4.Location = new Point(816, 558);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 53;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBarDecryption2);
            groupBox1.Controls.Add(btnDecryptKey);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(29, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(908, 123);
            groupBox1.TabIndex = 54;
            groupBox1.TabStop = false;
            groupBox1.Text = "Deskripsi Cipher Key";
            // 
            // progressBarDecryption2
            // 
            progressBarDecryption2.ForeColor = Color.Plum;
            progressBarDecryption2.Location = new Point(523, 45);
            progressBarDecryption2.Name = "progressBarDecryption2";
            progressBarDecryption2.Size = new Size(376, 27);
            progressBarDecryption2.TabIndex = 45;
            progressBarDecryption2.UseWaitCursor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBoxCipherImage);
            groupBox2.Location = new Point(29, 277);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(243, 256);
            groupBox2.TabIndex = 55;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cipher Image";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pictureBoxPlainImage);
            groupBox3.Location = new Point(281, 277);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(243, 256);
            groupBox3.TabIndex = 56;
            groupBox3.TabStop = false;
            groupBox3.Text = "Plain Image";
            // 
            // pictureBoxPlainImage
            // 
            pictureBoxPlainImage.Location = new Point(14, 28);
            pictureBoxPlainImage.Name = "pictureBoxPlainImage";
            pictureBoxPlainImage.Size = new Size(216, 216);
            pictureBoxPlainImage.TabIndex = 28;
            pictureBoxPlainImage.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(progressBarDecryption);
            groupBox4.Controls.Add(textBoxCipherImagePath);
            groupBox4.Controls.Add(buttonChooseImage_Click);
            groupBox4.Controls.Add(buttonUploadKey_Click);
            groupBox4.Controls.Add(buttonDecrypt);
            groupBox4.Controls.Add(textBoxSpritzKey);
            groupBox4.Controls.Add(buttonSaveImage);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(29, 196);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(908, 349);
            groupBox4.TabIndex = 57;
            groupBox4.TabStop = false;
            groupBox4.Text = "Deskripsi Cipher Image";
            groupBox4.Enter += groupBox4_Enter;
            // 
            // progressBarDecryption
            // 
            progressBarDecryption.ForeColor = Color.Plum;
            progressBarDecryption.Location = new Point(520, 253);
            progressBarDecryption.Name = "progressBarDecryption";
            progressBarDecryption.Size = new Size(379, 27);
            progressBarDecryption.TabIndex = 44;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 247, 255);
            ClientSize = new Size(958, 604);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(button4);
            Controls.Add(btnSaveSpritzKey);
            Controls.Add(lblDecryptionTime2);
            Controls.Add(btnLoadPrivateKey);
            Controls.Add(btnLoadCipherKey);
            Controls.Add(txtPrivateKey);
            Controls.Add(txtCipherKey);
            Controls.Add(labelDecryptionTime);
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
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlainImage).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private Button btnSaveSpritzKey;
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
    }
}