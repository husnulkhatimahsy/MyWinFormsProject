namespace WinFormsApp2
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
            label1 = new Label();
            button5 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            richTextBox1 = new RichTextBox();
            tabPage2 = new TabPage();
            richTextBox2 = new RichTextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(331, 30);
            label1.Name = "label1";
            label1.Size = new Size(293, 28);
            label1.TabIndex = 0;
            label1.Text = "Informasi Penggunaan Sistem";
            label1.Click += label1_Click;
            // 
            // button5
            // 
            button5.Location = new Point(803, 488);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 20;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(23, 77);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(912, 397);
            tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Silver;
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(904, 359);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sender (Pengirim)";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ButtonHighlight;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Microsoft Himalaya", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = SystemColors.MenuText;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(898, 353);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Silver;
            tabPage2.Controls.Add(richTextBox2);
            tabPage2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(904, 359);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Receiver (Penerima)";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = SystemColors.ButtonHighlight;
            richTextBox2.Dock = DockStyle.Fill;
            richTextBox2.Font = new Font("Microsoft Himalaya", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox2.Location = new Point(3, 3);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(898, 353);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 247, 255);
            ClientSize = new Size(958, 544);
            Controls.Add(tabControl1);
            Controls.Add(button5);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman Informasi";
            Load += Form2_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button5;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private RichTextBox richTextBox1;
        private TabPage tabPage2;
        private RichTextBox richTextBox2;
    }
}