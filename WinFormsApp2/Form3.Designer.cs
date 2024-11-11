namespace WinFormsApp2
{
    partial class Form3
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
            btnGenerate = new Button();
            textBoxPublicKey = new TextBox();
            textBoxPrivateKey = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button3 = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            textBoxPrimaQ = new TextBox();
            pictureBoxSave = new PictureBox();
            textBoxPrimaP = new TextBox();
            label5 = new Label();
            label2 = new Label();
            label7 = new Label();
            comboBoxKeySize = new ComboBox();
            label6 = new Label();
            groupBox2 = new GroupBox();
            label8 = new Label();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSave).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(151, 28);
            label1.Name = "label1";
            label1.Size = new Size(757, 58);
            label1.TabIndex = 0;
            label1.Text = "Halaman Pembangkitan Kunci Publik dan Kunci Privat dengan Algoritma RSA";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(204, 220, 36);
            btnGenerate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.ForeColor = Color.FromArgb(6, 52, 72);
            btnGenerate.Location = new Point(14, 33);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(382, 51);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate RSA Keys";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += button1_Click;
            // 
            // textBoxPublicKey
            // 
            textBoxPublicKey.Location = new Point(192, 127);
            textBoxPublicKey.Name = "textBoxPublicKey";
            textBoxPublicKey.Size = new Size(605, 31);
            textBoxPublicKey.TabIndex = 3;
            // 
            // textBoxPrivateKey
            // 
            textBoxPrivateKey.Location = new Point(192, 173);
            textBoxPrivateKey.Name = "textBoxPrivateKey";
            textBoxPrivateKey.Size = new Size(605, 31);
            textBoxPrivateKey.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 130);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 5;
            label3.Text = "Public Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 176);
            label4.Name = "label4";
            label4.Size = new Size(98, 25);
            label4.TabIndex = 6;
            label4.Text = "Private Key";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(5, 183, 171);
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(803, 38);
            button3.Name = "button3";
            button3.Size = new Size(114, 166);
            button3.TabIndex = 13;
            button3.Text = "\r\nSave\r\nKeys";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(876, 606);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 19;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxPrimaQ);
            groupBox1.Controls.Add(pictureBoxSave);
            groupBox1.Controls.Add(textBoxPrimaP);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxPrivateKey);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(textBoxPublicKey);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(53, 224);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(935, 238);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Key Results";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBoxPrimaQ
            // 
            textBoxPrimaQ.Location = new Point(192, 81);
            textBoxPrimaQ.Name = "textBoxPrimaQ";
            textBoxPrimaQ.Size = new Size(605, 31);
            textBoxPrimaQ.TabIndex = 17;
            textBoxPrimaQ.TextChanged += textBoxPrimaQ_TextChanged;
            // 
            // pictureBoxSave
            // 
            pictureBoxSave.BackColor = Color.FromArgb(5, 183, 171);
            pictureBoxSave.Location = new Point(843, 66);
            pictureBoxSave.Name = "pictureBoxSave";
            pictureBoxSave.Size = new Size(34, 37);
            pictureBoxSave.TabIndex = 21;
            pictureBoxSave.TabStop = false;
            // 
            // textBoxPrimaP
            // 
            textBoxPrimaP.Location = new Point(192, 38);
            textBoxPrimaP.Name = "textBoxPrimaP";
            textBoxPrimaP.Size = new Size(605, 31);
            textBoxPrimaP.TabIndex = 16;
            textBoxPrimaP.TextChanged += textBoxPrimaP_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 82);
            label5.Name = "label5";
            label5.Size = new Size(145, 25);
            label5.TabIndex = 15;
            label5.Text = "Bilangan Prima q";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 38);
            label2.Name = "label2";
            label2.Size = new Size(145, 25);
            label2.TabIndex = 14;
            label2.Text = "Bilangan Prima p";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(76, 477);
            label7.Name = "label7";
            label7.Size = new Size(460, 76);
            label7.TabIndex = 22;
            label7.Text = "Petunjuk:\r\n1. Pilih panjang kunci RSA. \r\n2. Klik 'Generate RSA Keys' untuk membangkitkan kunci publik dan privat.\r\n3. Klik 'Save Keys' untuk menyimpan kunci publik dan kunci privat.";
            label7.Click += label7_Click;
            // 
            // comboBoxKeySize
            // 
            comboBoxKeySize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKeySize.FormattingEnabled = true;
            comboBoxKeySize.Items.AddRange(new object[] { "[1024 bit] - Keamanan dasar", "[2048 bit] - Keamanan menengah (Direkomendasikan)", "[4096 bit] - Keamanan tinggi" });
            comboBoxKeySize.Location = new Point(23, 75);
            comboBoxKeySize.Name = "comboBoxKeySize";
            comboBoxKeySize.Size = new Size(473, 33);
            comboBoxKeySize.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 33);
            label6.Name = "label6";
            label6.Size = new Size(393, 25);
            label6.TabIndex = 19;
            label6.Text = "Silakan pilih panjang kunci RSA yang diinginkan:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxKeySize);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(53, 89);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(515, 125);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "RSA Key Settings";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(11, 97);
            label8.Name = "label8";
            label8.Size = new Size(391, 15);
            label8.TabIndex = 21;
            label8.Text = "⚠️ Peringatan: Kunci RSA hanya bisa digenerate satu kali dalam satu sesi.";
            label8.Click += label8_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnGenerate);
            groupBox3.Controls.Add(label8);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(574, 89);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(414, 125);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Generate RSA Keys";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 247, 255);
            ClientSize = new Size(1038, 669);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label7);
            Controls.Add(button5);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman Pembangkitan Kunci RSA";
            Load += Form3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSave).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGenerate;
        private TextBox textBoxPublicKey;
        private TextBox textBoxPrivateKey;
        private Label label3;
        private Label label4;
        private Button button3;
        private Button button5;
        private GroupBox groupBox1;
        private TextBox textBoxPrimaQ;
        private TextBox textBoxPrimaP;
        private Label label5;
        private Label label2;
        private PictureBox pictureBoxSave;
        private Label label7;
        private ComboBox comboBoxKeySize;
        private Label label6;
        private GroupBox groupBox2;
        private Label label8;
        private GroupBox groupBox3;
    }
}