﻿namespace WinFormsApp2
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
            tabPage3 = new TabPage();
            richTextBox3 = new RichTextBox();
            tabPage4 = new TabPage();
            richTextBox4 = new RichTextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(367, 24);
            label1.Name = "label1";
            label1.Size = new Size(293, 28);
            label1.TabIndex = 0;
            label1.Text = "Informasi Penggunaan Sistem";
            // 
            // button5
            // 
            button5.Location = new Point(892, 619);
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
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(39, 77);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(965, 531);
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
            tabPage1.Size = new Size(957, 493);
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
            richTextBox1.Size = new Size(951, 487);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Silver;
            tabPage2.Controls.Add(richTextBox2);
            tabPage2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(957, 493);
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
            richTextBox2.Size = new Size(951, 487);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(richTextBox3);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(957, 493);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Pengenalan Kunci";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            richTextBox3.BackColor = SystemColors.ButtonHighlight;
            richTextBox3.Font = new Font("Microsoft Himalaya", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox3.Location = new Point(1, -1);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox3.Size = new Size(956, 491);
            richTextBox3.TabIndex = 0;
            richTextBox3.Text = resources.GetString("richTextBox3.Text");
            richTextBox3.TextChanged += richTextBox3_TextChanged;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(richTextBox4);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(957, 493);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Contoh Skenario";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox4
            // 
            richTextBox4.BackColor = SystemColors.ButtonHighlight;
            richTextBox4.Font = new Font("Microsoft Himalaya", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox4.Location = new Point(0, 0);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(954, 490);
            richTextBox4.TabIndex = 0;
            richTextBox4.Text = resources.GetString("richTextBox4.Text");
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 247, 255);
            ClientSize = new Size(1038, 669);
            Controls.Add(tabControl1);
            Controls.Add(button5);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman Informasi";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
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
        private TabPage tabPage3;
        private RichTextBox richTextBox3;
        private TabPage tabPage4;
        private RichTextBox richTextBox4;
    }
}