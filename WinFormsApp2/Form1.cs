using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set AutoScaleMode untuk form ini
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Event handlers untuk efek hover pada tombol
            button1.MouseEnter += Button_MouseEnter;
            button1.MouseLeave += Button_MouseLeave;

            button2.MouseEnter += Button_MouseEnter;
            button2.MouseLeave += Button_MouseLeave;

            button3.MouseEnter += Button_MouseEnter;
            button3.MouseLeave += Button_MouseLeave;

            button4.MouseEnter += Button_MouseEnter;
            button4.MouseLeave += Button_MouseLeave;

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImages();
        }

        private void LoadImages()
        {
            // Pastikan jalur relatif benar berdasarkan lokasi gambar di folder proyek
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath1 = Path.Combine(basePath, "Resources", "lock.png");
            string imagePath2 = Path.Combine(basePath, "Resources", "unlock.png");
            string imagePath3 = Path.Combine(basePath, "Resources", "information.png");
            string imagePath4 = Path.Combine(basePath, "Resources", "keysrsa.png");

            // Setel gambar ke PictureBox
            pictureBox1.Image = Image.FromFile(imagePath1);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Menyesuaikan ukuran gambar dengan ukuran PictureBox

            pictureBox2.Image = Image.FromFile(imagePath2);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // Menyesuaikan ukuran gambar dengan ukuran PictureBox

            pictureBox3.Image = Image.FromFile(imagePath3);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage; // Menyesuaikan ukuran gambar dengan ukuran PictureBox

            pictureBox4.Image = Image.FromFile(imagePath4);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage; // Menyesuaikan ukuran gambar dengan ukuran PictureBox
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
            Form3 form3 = new Form3();
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

        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.FromArgb(19, 123, 110);
            }
            // Jika button adalah null, tidak ada perubahan yang dilaku
        }

        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.FromArgb(12, 188, 172);
            }
            // Jika button adalah null, tidak ada perubahan yang dilaku
        }
    }
}