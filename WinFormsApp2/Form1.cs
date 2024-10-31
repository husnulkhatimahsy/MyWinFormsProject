using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public bool rsaKeyGenerated = false; // Variabel di tingkat Form1
        private OverallCPUMonitor cpuMonitor;

        public Form1()
        {
            InitializeComponent();

            // Set AutoScaleMode untuk form ini
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Mengatur efek hover tombol secara lebih efisien
            SetButtonHoverEffects();

            cpuMonitor = new OverallCPUMonitor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImages();
            // Mulai monitoring saat aplikasi dimulai
            cpuMonitor.StartMonitoring();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cpuMonitor.StopMonitoring();
        }

        private void LoadImages()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;

                pictureBox1.Image = LoadImage(Path.Combine(basePath, "Resources", "lock.png"));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox2.Image = LoadImage(Path.Combine(basePath, "Resources", "unlock.png"));
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox3.Image = LoadImage(Path.Combine(basePath, "Resources", "information.png"));
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox4.Image = LoadImage(Path.Combine(basePath, "Resources", "keysrsa.png"));
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat gambar: " + ex.Message);
            }
        }

        private Image LoadImage(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Gambar tidak ditemukan: {path}");

            return Image.FromFile(path);
        }

        private void SetButtonHoverEffects()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this); // Kirim referensi ke Form1
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private readonly Color HoverColor = Color.FromArgb(19, 123, 110);
        private readonly Color DefaultColor = Color.FromArgb(12, 188, 172);

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = HoverColor;
            }
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = DefaultColor;
            }
        }

    }
}
