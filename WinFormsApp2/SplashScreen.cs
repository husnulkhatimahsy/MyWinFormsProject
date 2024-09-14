using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            LoadImages(); // Panggil metode untuk memuat gambar
            timer1.Start(); // Mulai timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); // Hentikan timer setelah tick
            this.Close();  // Tutup splash screen
        }

        private void LoadImages()
        {
            try
            {
                // Pastikan jalur relatif benar berdasarkan lokasi gambar di folder proyek
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath1 = Path.Combine(basePath, "Resources", "logounhas.png");

                // Setel gambar ke PictureBox
                pictureBox1.Image = Image.FromFile(imagePath1);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Menyesuaikan ukuran gambar dengan ukuran PictureBox
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Gambar tidak ditemukan: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat gambar: " + ex.Message);
            }
        }
    }
}