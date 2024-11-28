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
        private byte[] encryptedImageData = Array.Empty<byte>();
        private int imgWidth;
        private int imgHeight;
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
                    using (Bitmap img = new Bitmap(filePath)) // Mendeklarasikan dan menginisialisasi img
                    {
                        // Tampilkan gambar di PictureBox
                        pictureBoxSelectedImage.Image = new Bitmap(img); // Salin img ke PictureBox
                        pictureBoxSelectedImage.SizeMode = PictureBoxSizeMode.Zoom;

                        // Tampilkan path gambar di TextBox
                        textBoxImagePath.Text = filePath;

                        // Tetapkan nilai imgWidth dan imgHeight
                        imgWidth = img.Width;
                        imgHeight = img.Height;

                        // Perbarui status gambar menjadi "Citra Asli"
                        UpdateImageStatus("Citra Asli");
                    }
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

            // Setelah enkripsi selesai, hitung dan simpan entropi
            double entropy = CalculateEntropy(encryptedImageData);
            SaveEntropyToFile(entropy);
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
                    encryptedImageData = new byte[width * height];

                    progressBarEncryption.Minimum = 0;
                    progressBarEncryption.Maximum = height * width;
                    progressBarEncryption.Value = 0;

                    // Membaca data gambar asli
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixelColor = img.GetPixel(x, y);
                            imageData[y * width + x] = pixelColor.R; // Gambar grayscale jadi hanya channel R yang digunakan
                        }
                    }

                    // Mengenkripsi data gambar
                    byte[] keystream = GenerateKeystream(width * height);
                    for (int i = 0; i < imageData.Length; i++)
                    {
                        encryptedImageData[i] = (byte)(imageData[i] ^ keystream[i]);
                        progressBarEncryption.Value = i + 1;
                    }

                    // Membuat gambar terenkripsi dari data terenkripsi
                    Bitmap encryptedImg = new Bitmap(width, height);
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            byte pixelValue = encryptedImageData[y * width + x];
                            encryptedImg.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue)); // Gambar grayscale
                        }
                    }

                    // Tampilkan gambar terenkripsi di PictureBox
                    pictureBoxEncrypted.Image = encryptedImg;
                    pictureBoxEncrypted.SizeMode = PictureBoxSizeMode.Zoom;

                    MessageBox.Show("Gambar berhasil dienkripsi dan ditampilkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private double CalculateEntropy(byte[] data)
        {
            int[] frequency = new int[256];

            // Menghitung frekuensi setiap nilai byte (0-255)
            foreach (var b in data)
            {
                frequency[b]++;
            }

            double entropy = 0.0;
            int dataSize = data.Length;

            // Menghitung entropi berdasarkan frekuensi
            foreach (var count in frequency)
            {
                if (count == 0) continue; // Lewati nilai byte yang tidak ada
                double probability = (double)count / dataSize;
                entropy -= probability * Math.Log2(probability);
            }

            return entropy;
        }

        private void SaveEntropyToFile(double entropy)
        {
            string filePath = @"D:\Skripsi\File\Python\Pengujian\entropi.txt";
            string content = $"Entropi: {entropy:F4} pada {DateTime.Now}\n"; // Menampilkan 4 angka di belakang koma

            try
            {
                // Tulis entropi ke file dalam mode append
                File.AppendAllText(filePath, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan nilai entropi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (encryptedImageData == null || encryptedImageData.Length == 0)
            {
                MessageBox.Show("Tidak ada data terenkripsi untuk disimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Citra Medis Encrypted",
                Filter = "Encrypted Files (*.enc)|*.enc",
                FileName = "encrypted_image.enc",
                Title = "Simpan Gambar Terenkripsi"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    using (var writer = new BinaryWriter(fs))
                    {
                        // Pastikan ukuran data terenkripsi sesuai dengan dimensi gambar
                        if (encryptedImageData.Length != imgWidth * imgHeight)
                        {
                            MessageBox.Show("Data gambar terenkripsi tidak sesuai dengan ukuran lebar dan tinggi gambar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Tulis metadata lebar dan tinggi gambar
                        writer.Write(imgWidth);  // Lebar gambar
                        writer.Write(imgHeight); // Tinggi gambar
                        writer.Write(encryptedImageData); // Data gambar terenkripsi
                    }

                    MessageBox.Show($"Data terenkripsi berhasil disimpan sebagai {saveFileDialog.FileName}.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan data terenkripsi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // Menampilkan kunci publik di TextBox
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