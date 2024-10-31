using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form4 : Form
    {
        private RSA rsa;
        private byte[] spritzKey;
        private byte[] encryptedSpritzKey = Array.Empty<byte>(); // Inisialisasi dengan array kosong
        private CPUMonitor cpuMonitor;

        public Form4()
        {
            InitializeComponent();
            rsa = RSA.Create(); // Inisialisasi RSA
            spritzKey = Array.Empty<byte>(); // Inisialisasi dengan array kosong
            cpuMonitor = new CPUMonitor(); // Inisialisasi CPUMonitor
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int panjangKunci = 16;
            spritzKey = GenerateSpritzKey(panjangKunci);

            // Konversi byte array ke format string untuk ditampilkan
            string spritzKeyString = BitConverter.ToString(spritzKey).Replace("-", "");

            textBoxSpritzKey.Text = spritzKeyString;
            // Setelah generate, tombol di-disable
            button2.Enabled = false;
            button2.BackColor = Color.Gray; // Ubah warna ke abu-abu
        }

        private byte[] GenerateSpritzKey(int keyLength)
        {
            // Membuat instance Spritz cipher
            Spritz spritz = new Spritz();

            // Generate kunci acak 128-bit untuk Spritz
            byte[] randomKey = GenerateRandomKey();

            // Set kunci pada Spritz cipher
            spritz.SetKey(randomKey);

            // Generate keystream sepanjang panjang kunci
            return spritz.GenerateKeystream(keyLength);
        }

        private byte[] GenerateRandomKey()
        {
            // Menghasilkan kunci acak 128-bit (16 byte)
            byte[] randomKey = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomKey);
            }
            return randomKey;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void UpdateImageStatus(string status)
        {
            labelStatus.Text = $"Status Citra: {status}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Citra Medis",
                Filter = "File Gambar (*.jpg, *.jpeg) | *.jpg; *.jpeg",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Tampilkan gambar di PictureBox
                    pictureBoxSelectedImage.Image = Image.FromFile(filePath);
                    pictureBoxSelectedImage.SizeMode = PictureBoxSizeMode.Zoom;

                    // Tampilkan path gambar di TextBox
                    textBoxImagePath.Text = filePath;

                    // Perbarui status gambar menjadi "Citra Asli"
                    UpdateImageStatus("Citra Asli");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menampilkan gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (spritzKey == null || spritzKey.Length == 0)
            {
                MessageBox.Show("Harap generate kunci Spritz terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci Spritz",
                Filter = "Binary Files (*.bin)|*.bin",
                FileName = "spritz_key.bin"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, spritzKey);
                    MessageBox.Show("Kunci Spritz berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan kunci Spritz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (spritzKey == null || spritzKey.Length == 0)
            {
                MessageBox.Show("Harap generate kunci Spritz terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string imagePath = textBoxImagePath.Text;

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Harap pilih gambar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mulai CPU Monitoring
            cpuMonitor.StartMonitoring();

            // Menggunakan Stopwatch untuk mengukur waktu enkripsi
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Mulai mengukur waktu

            EncryptImage(imagePath, spritzKey);

            stopwatch.Stop(); // Hentikan pengukuran waktu
            cpuMonitor.StopMonitoring(); // Hentikan CPU Monitoring

            double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds; // Mengambil waktu dalam detik
            labelEncryptionTime.Text = $"Waktu Enkripsi: {elapsedTimeInSeconds} detik";

            // Menampilkan hasil penggunaan CPU rata-rata
            double avgCpuUsage = cpuMonitor.GetAverageCpuUsage();

            // Setelah perhitungan avgCpuUsage selesai
            string filePath = @"D:\Skripsi\File\Python\Pengujian\HasilPenggunaanCPUEnkripsiCitra.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Penggunaan CPU rata-rata selama Enkripsi Citra Medis: {avgCpuUsage:F2}% pada {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat menyimpan hasil penggunaan CPU: {ex.Message}");
            }

            // Setelah berhasil enkripsi
            UpdateImageStatus("Citra Terenkripsi");
        }

        /*
        private byte[] EncryptData(byte[] data, byte[] spritzKey)
        {
            byte[] encryptedData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                encryptedData[i] = (byte)(data[i] ^ spritzKey[i % spritzKey.Length]);
            }
            return encryptedData;
        }*/

        private void EncryptImage(string imagePath, byte[] spritzKey)
        {
            try
            {
                using (Bitmap img = new Bitmap(imagePath))
                {
                    int width = img.Width;
                    int height = img.Height;
                    byte[] imageData = new byte[width * height];
                    byte[] encryptedImageData = new byte[width * height];

                    // Inisialisasi progress bar
                    progressBarEncryption.Minimum = 0;
                    progressBarEncryption.Maximum = height * width;
                    progressBarEncryption.Value = 0;

                    // Membaca data gambar
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixelColor = img.GetPixel(x, y);
                            imageData[y * width + x] = pixelColor.R; // Gambar grayscale jadi hanya R yang diambil
                        }
                    }

                    // Mengenkripsi data gambar
                    byte[] keystream = GenerateKeystream(width * height);
                    for (int i = 0; i < imageData.Length; i++)
                    {
                        encryptedImageData[i] = (byte)(imageData[i] ^ keystream[i]);
                        progressBarEncryption.Value = i + 1; // Update progress bar
                    }

                    // Simpan gambar terenkripsi
                    Bitmap encryptedImg = new Bitmap(width, height);
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            byte pixelValue = encryptedImageData[y * width + x];
                            encryptedImg.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                        }
                    }

                    // Tampilkan gambar terenkripsi di PictureBox
                    pictureBoxEncrypted.Image = encryptedImg;
                    pictureBoxEncrypted.SizeMode = PictureBoxSizeMode.Zoom;

                    MessageBox.Show("Gambar berhasil dienkripsi. Silakan simpan gambar terenkripsi menggunakan tombol 'Save Cipher Image'.",
                                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengenkripsi gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GenerateKeystream(int length)
        {
            Spritz spritz = new Spritz();
            spritz.SetKey(spritzKey);
            return spritz.GenerateKeystream(length);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBoxEncrypted.Image == null)
            {
                MessageBox.Show("Tidak ada gambar terenkripsi untuk disimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Citra Medis Encrypted",
                Filter = "Bitmap Image (*.bmp)|*.bmp",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName = "encrypt_image.bmp" // Nama default file
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    pictureBoxEncrypted.Image.Save(filePath);
                    MessageBox.Show($"Gambar berhasil disimpan sebagai {filePath}.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Load RSA Public Key
        private void buttonRsaPublicKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci RSA",
                Filter = "PEM Files (*.pem)|*.pem",
                Title = "Pilih Kunci Publik RSA"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string publicKeyPath = openFileDialog.FileName;
                string rsaPublicKeyPem = File.ReadAllText(publicKeyPath);

                try
                {
                    // Konversi PEM ke format byte[]
                    byte[] rsaPublicKeyBytes = ConvertPemToBytes(rsaPublicKeyPem);

                    // Mengimpor kunci publik dengan format X.509
                    rsa.ImportSubjectPublicKeyInfo(rsaPublicKeyBytes, out _);
                    textBoxRsaPublicKey.Text = rsaPublicKeyPem; // Tampilkan di TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memuat kunci publik RSA: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Mengonversi PEM ke Format Byte[]
        private byte[] ConvertPemToBytes(string pem)
        {
            var pemHeader = "-----BEGIN PUBLIC KEY-----";
            var pemFooter = "-----END PUBLIC KEY-----";

            var base64 = pem.Replace(pemHeader, "").Replace(pemFooter, "").Replace("\r", "").Replace("\n", "");
            return Convert.FromBase64String(base64);
        }

        private void buttonLoadSpritzKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci Spritz",
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Select Spritz Key"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string spritzKeyPath = openFileDialog.FileName;
                try
                {
                    byte[] spritzKey = File.ReadAllBytes(spritzKeyPath);
                    textBoxSpritzKey2.Text = BitConverter.ToString(spritzKey).Replace("-", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
        }

        private void buttonEncryptSpritzKey_Click(object sender, EventArgs e)
        {
            if (rsa == null || spritzKey == null)
            {
                MessageBox.Show("Silakan muat baik kunci publik RSA maupun kunci Spritz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mulai CPU Monitoring
            cpuMonitor.StartMonitoring();

            // Menggunakan Stopwatch untuk mengukur waktu enkripsi
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Mulai mengukur waktu

            try
            {
                encryptedSpritzKey = rsa.Encrypt(spritzKey, RSAEncryptionPadding.Pkcs1); // Enkripsi kunci Spritz

                stopwatch.Stop(); // Hentikan pengukuran waktu
                double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds; // Mengambil waktu dalam detik
                labelEncryptionTime2.Text = $"Waktu Enkripsi: {elapsedTimeInSeconds} detik";

                // Simulasi pembaruan progress bar
                progressBarEncryption2.Value = 100;

                // Hentikan CPU Monitoring
                cpuMonitor.StopMonitoring();

                // Ambil rata-rata penggunaan CPU selama proses enkripsi
                double avgCpuUsage = cpuMonitor.GetAverageCpuUsage();

                // Setelah perhitungan avgCpuUsage selesai
                string filePath = @"D:\Skripsi\File\Python\Pengujian\HasilPenggunaanCPUEnkripsiKey.txt";

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine($"Penggunaan CPU rata-rata selama enkripsi kunci: {avgCpuUsage:F2}% pada {DateTime.Now}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saat menyimpan hasil penggunaan CPU: {ex.Message}");
                }

                // Notifikasi bahwa kunci berhasil didekripsi
                MessageBox.Show("Kunci Spritz berhasil dienkripsi.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengenkripsi kunci Spritz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSaveCipherKey_Click(object sender, EventArgs e)
        {
            if (encryptedSpritzKey == null)
            {
                MessageBox.Show("Tidak ada kunci Spritz yang dienkripsi untuk disimpan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci Spritz Encrypted",
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Simpan Kunci Spritz yang Dienkripsi",
                FileName = "encrypted_spritz_key.bin"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, encryptedSpritzKey);
                    MessageBox.Show("Kunci Spritz yang dienkripsi berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan kunci Spritz yang dienkripsi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void buttonResetKey_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin reset kunci Spritz?", "Konfirmasi Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Reset key logic
                spritzKey = Array.Empty<byte>(); // Hapus kunci
                textBoxSpritzKey.Clear(); // Hapus dari TextBox
                button2.Enabled = true; // Enable kembali tombol generate
                button2.BackColor = Color.FromArgb(204, 220, 36); // Ubah warna ke warna semula
            }
        }
    }
}