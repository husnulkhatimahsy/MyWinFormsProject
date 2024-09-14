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
            GenerateTime = new Label();
            textBoxPrimaQ = new TextBox();
            textBoxPrimaP = new TextBox();
            label5 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(107, 36);
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
            btnGenerate.Location = new Point(658, 55);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(197, 77);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += button1_Click;
            // 
            // textBoxPublicKey
            // 
            textBoxPublicKey.Location = new Point(236, 144);
            textBoxPublicKey.Name = "textBoxPublicKey";
            textBoxPublicKey.Size = new Size(378, 31);
            textBoxPublicKey.TabIndex = 3;
            // 
            // textBoxPrivateKey
            // 
            textBoxPrivateKey.Location = new Point(236, 190);
            textBoxPrivateKey.Name = "textBoxPrivateKey";
            textBoxPrivateKey.Size = new Size(378, 31);
            textBoxPrivateKey.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 147);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 5;
            label3.Text = "Public Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 193);
            label4.Name = "label4";
            label4.Size = new Size(105, 25);
            label4.TabIndex = 6;
            label4.Text = "Private Key";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(5, 183, 171);
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(658, 148);
            button3.Name = "button3";
            button3.Size = new Size(197, 73);
            button3.TabIndex = 13;
            button3.Text = "Save Keys";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(796, 503);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 19;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(GenerateTime);
            groupBox1.Controls.Add(textBoxPrimaQ);
            groupBox1.Controls.Add(textBoxPrimaP);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxPrivateKey);
            groupBox1.Controls.Add(textBoxPublicKey);
            groupBox1.Controls.Add(btnGenerate);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(53, 126);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(866, 306);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generate RSA Keys";
            // 
            // GenerateTime
            // 
            GenerateTime.AutoSize = true;
            GenerateTime.Location = new Point(23, 257);
            GenerateTime.Name = "GenerateTime";
            GenerateTime.Size = new Size(244, 25);
            GenerateTime.TabIndex = 18;
            GenerateTime.Text = "Waktu Generate Kunci RSA: ";
            // 
            // textBoxPrimaQ
            // 
            textBoxPrimaQ.Location = new Point(236, 99);
            textBoxPrimaQ.Name = "textBoxPrimaQ";
            textBoxPrimaQ.Size = new Size(378, 31);
            textBoxPrimaQ.TabIndex = 17;
            textBoxPrimaQ.TextChanged += textBoxPrimaQ_TextChanged;
            // 
            // textBoxPrimaP
            // 
            textBoxPrimaP.Location = new Point(236, 55);
            textBoxPrimaP.Name = "textBoxPrimaP";
            textBoxPrimaP.Size = new Size(378, 31);
            textBoxPrimaP.TabIndex = 16;
            textBoxPrimaP.TextChanged += textBoxPrimaP_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 99);
            label5.Name = "label5";
            label5.Size = new Size(153, 25);
            label5.TabIndex = 15;
            label5.Text = "Bilangan Prima q";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 55);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 14;
            label2.Text = "Bilangan Prima p";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 247, 255);
            ClientSize = new Size(963, 549);
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
            ResumeLayout(false);
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
        private Label GenerateTime;
    }
}