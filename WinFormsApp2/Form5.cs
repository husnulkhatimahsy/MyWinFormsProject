using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WinFormsApp2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsApp2
{
    public partial class Form5 : Form
    {
        // Deklarasi spritzKey sebagai array byte
        private byte[] spritzKey;
        // Deklarasi variabel decryptedSpritzKey sebagai array byte
        private byte[]? decryptedSpritzKey;
        private CPUMonitor cpuMonitor; // Inisialisasi CPUMonitor

        public Form5()
        {
            InitializeComponent();
            spritzKey = Array.Empty<byte>(); // Inisialisasi dengan array kosong
            cpuMonitor = new CPUMonitor(); // Inisialisasi CPUMonitor
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnLoadPrivateKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci RSA",
                Filter = "PEM Files (*.pem)|*.pem",
                Title = "Pilih Kunci Privat RSA"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string privateKeyPath = openFileDialog.FileName;
                string privateKeyPem = File.ReadAllText(privateKeyPath);

                try
                {
                    // Validasi format PEM kunci privat
                    if (privateKeyPem.Contains("-----BEGIN RSA PRIVATE KEY-----") && privateKeyPem.Contains("-----END RSA PRIVATE KEY-----"))
                    {
                        // Tampilkan kunci privat di TextBox
                        txtPrivateKey.Text = privateKeyPem;
                    }
                    else
                    {
                        MessageBox.Show("File yang dipilih bukan kunci privat RSA yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memuat kunci privat RSA: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLoadCipherKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci Spritz Encrypted",
                Filter = "Cipher Key Files (*.bin)|*.bin",
                Title = "Pilih File Kunci Cipher"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string cipherKeyPath = openFileDialog.FileName;
                byte[] cipherKeyBytes = File.ReadAllBytes(cipherKeyPath);

                try
                {
                    // Konversi byte[] ke format hex string dan tampilkan di TextBox
                    txtCipherKey.Text = BitConverter.ToString(cipherKeyBytes).Replace("-", " ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memuat kunci cipher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDecryptKey_Click(object sender, EventArgs e)
        {
            try
            {
                // Memuat kunci privat RSA dari textBox
                string privateKeyPem = txtPrivateKey.Text;

                if (string.IsNullOrEmpty(privateKeyPem))
                {
                    MessageBox.Show("Silakan muat kunci privat RSA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Memuat cipherkey (Spritz key) dari TextBox
                byte[] cipherKey;
                try
                {
                    cipherKey = ConvertHexStringToByteArray(txtCipherKey.Text.Replace(" ", ""));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal mengonversi kunci cipher dari teks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cpuMonitor.StartMonitoring(); // Mulai pengujian CPU

                // Menggunakan Stopwatch untuk mengukur waktu dekripsi
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); // Mulai mengukur waktu


                // Dekripsi kunci Spritz menggunakan RSA
                byte[] spritzKey;
                try
                {
                    spritzKey = DecryptCipherKeyWithRSA(cipherKey, privateKeyPem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal mendekripsi kunci cipher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                stopwatch.Stop(); // Hentikan pengukuran waktu

                cpuMonitor.StopMonitoring(); // Hentikan pengujian CPU

                double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds; // Mengambil waktu dalam detik

                // Menampilkan waktu dekripsi
                lblDecryptionTime2.Text = $"Waktu Dekripsi: {elapsedTimeInSeconds} detik";

                double avgCpuUsage = cpuMonitor.GetAverageCpuUsage();

                // Setelah perhitungan avgCpuUsage selesai
                string filePath = @"D:\Skripsi\File\Python\Pengujian\HasilPenggunaanCPUDekripsiKey.txt";

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine($"Penggunaan CPU rata-rata selama dekripsi kunci: {avgCpuUsage:F2}% pada {DateTime.Now}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saat menyimpan hasil penggunaan CPU: {ex.Message}");
                }

                // Update progress bar (diatur ke 100% jika proses dekripsi berhasil)
                progressBarDecryption2.Value = 100;

                // Menyimpan kunci Spritz yang telah didekripsi untuk digunakan di bagian lain dari program
                decryptedSpritzKey = spritzKey;

                // Menyimpan kunci Spritz yang telah didekripsi dan menampilkannya di TextBoxSpritzKey
                decryptedSpritzKey = spritzKey;
                textBoxSpritzKey.Text = BitConverter.ToString(decryptedSpritzKey).Replace("-", "");

                // Mengisi variabel spritzKey untuk digunakan dalam proses dekripsi gambar
                this.spritzKey = decryptedSpritzKey;  // Pastikan spritzKey diisi dengan kunci yang sudah didekripsi

                // Nonaktifkan tombol "Upload Spritz Key" setelah dekripsi berhasil
                buttonUploadKey_Click.Enabled = false;
                buttonUploadKey_Click.BackColor = Color.Gray; // Ubah warna menjadi abu-abu untuk menandakan nonaktif


                // Notifikasi bahwa kunci berhasil didekripsi
                MessageBox.Show("Kunci Spritz berhasil didekripsi.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] DecryptCipherKeyWithRSA(byte[] cipherKey, string privateKeyPem)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(ConvertPemToBytes(privateKeyPem), out _);
                return rsa.Decrypt(cipherKey, RSAEncryptionPadding.Pkcs1);
            }
        }

        private byte[] ConvertHexStringToByteArray(string hex)
        {
            int numberOfChars = hex.Length;
            byte[] bytes = new byte[numberOfChars / 2];
            for (int i = 0; i < numberOfChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private RSAParameters ImportPrivateKeyFromPem(string pem)
        {
            // Menggunakan ConvertPemToBytes untuk mendapatkan byte[] dari PEM
            byte[] privateKeyBytes = ConvertPemToBytes(pem);

            // Decode PKCS#1 private key
            using (var memoryStream = new MemoryStream(privateKeyBytes))
            using (var reader = new BinaryReader(memoryStream))
            {
                return ReadRSAPrivateKey(reader);
            }
        }

        private byte[] ConvertPemToBytes(string pem)
        {
            var pemHeader = "-----BEGIN RSA PRIVATE KEY-----";
            var pemFooter = "-----END RSA PRIVATE KEY-----";

            var base64 = pem.Replace(pemHeader, "").Replace(pemFooter, "").Replace("\r", "").Replace("\n", "");
            return Convert.FromBase64String(base64);
        }

        private RSAParameters ReadRSAPrivateKey(BinaryReader reader)
        {
            var rsaParameters = new RSAParameters
            {
                Modulus = ReadInteger(reader),
                Exponent = ReadInteger(reader),
                D = ReadInteger(reader),
                P = ReadInteger(reader),
                Q = ReadInteger(reader),
                DP = ReadInteger(reader),
                DQ = ReadInteger(reader),
                InverseQ = ReadInteger(reader)
            };

            return rsaParameters;
        }

        private byte[] ReadInteger(BinaryReader reader)
        {
            ushort length;
            var firstByte = reader.ReadByte();
            if (firstByte == 0x81)
                length = reader.ReadByte();
            else if (firstByte == 0x82)
                length = reader.ReadUInt16();
            else
                length = firstByte;

            return reader.ReadBytes(length);
        }

        /*private void btnSaveSpritzKey_Click(object sender, EventArgs e)
        {
            if (decryptedSpritzKey == null || decryptedSpritzKey.Length == 0)
            {
                MessageBox.Show("Tidak ada kunci Spritz yang didekripsi untuk disimpan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci Spritz Decrypted",
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Simpan Kunci Spritz",
                FileName = "decrypted_spritz_key.bin"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, decryptedSpritzKey);
                    MessageBox.Show("Kunci Spritz berhasil disimpan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan kunci Spritz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }*/

        private void UpdateImageStatus(string status)
        {
            labelStatus2.Text = $"Status Citra: {status}";
        }

        private void buttonChooseImage_Click_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Citra Medis Encrypted",
                Filter = "Encrypted Files (*.enc)|*.enc",
                Title = "Pilih File Gambar Terenkripsi (.enc)"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string encryptedFilePath = openFileDialog.FileName;
                textBoxCipherImagePath.Text = encryptedFilePath;
                DisplayCipherImage(encryptedFilePath); // Panggil metode untuk menampilkan gambar terenkripsi

                // Perbarui status gambar menjadi "Citra hasil dekripsi"
                UpdateImageStatus("Citra Terenkripsi");
            }
        }

        private void DisplayCipherImage(string encryptedFilePath)
        {
            try
            {
                using (FileStream fs = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int width = reader.ReadInt32(); // Membaca lebar gambar
                    int height = reader.ReadInt32(); // Membaca tinggi gambar

                    // Membaca data terenkripsi
                    byte[] encryptedImageData = reader.ReadBytes(width * height);

                    Bitmap cipherImg = new Bitmap(width, height);

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            byte pixelValue = encryptedImageData[y * width + x];
                            cipherImg.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue)); // Grayscale
                        }
                    }

                    pictureBoxCipherImage.Image = cipherImg;
                    pictureBoxCipherImage.SizeMode = PictureBoxSizeMode.Zoom;
                    MessageBox.Show("Gambar terenkripsi berhasil ditampilkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menampilkan gambar terenkripsi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxCipherImagePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void buttonUploadKey_Click_Click(object sender, EventArgs e)
        {
            // Jika textboxSpritzKey kosong, izinkan unggah kunci Spritz dari file
            if (string.IsNullOrEmpty(textBoxSpritzKey.Text))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci Spritz",
                    Filter = "Binary Files (*.bin)|*.bin",
                    Title = "Select Spritz Key File"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        spritzKey = File.ReadAllBytes(openFileDialog.FileName);
                        // Menampilkan kunci di TextBox 
                        textBoxSpritzKey.Text = BitConverter.ToString(spritzKey).Replace("-", "");
                        MessageBox.Show("Kunci Spritz berhasil dimuat.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Nonaktifkan tombol upload key setelah file diunggah
                        buttonUploadKey_Click.Enabled = false;
                        buttonUploadKey_Click.BackColor = Color.Gray; // Ubah warna menjadi abu-abu untuk menandakan nonaktif
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gagal memuat kunci Spritz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Kunci Spritz sudah ada, tidak bisa upload lagi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private byte[] GenerateKeystream(int length)
        {
            Spritz spritz = new Spritz();
            spritz.SetKey(spritzKey);
            return spritz.GenerateKeystream(length); // Menghasilkan keystream sepanjang 'length'
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (spritzKey == null || spritzKey.Length == 0)
            {
                MessageBox.Show("Harap muat kunci Spritz terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textBoxCipherImagePath.Text))
            {
                MessageBox.Show("Harap pilih gambar terenkripsi terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cipherImagePath = textBoxCipherImagePath.Text;

            cpuMonitor.StartMonitoring(); // Mulai pengujian CPU
            // Menggunakan Stopwatch untuk mengukur waktu dekripsi
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Mulai mengukur waktu

            // Dekripsi gambar
            DecryptImage(cipherImagePath, spritzKey);

            stopwatch.Stop(); // Hentikan pengukuran waktu
            cpuMonitor.StopMonitoring(); // Hentikan pengujian CPU
            double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds; // Mengambil waktu dalam detik

            labelDecryptionTime.Text = $"Waktu Dekripsi: {elapsedTimeInSeconds} detik";

            double avgCpuUsage = cpuMonitor.GetAverageCpuUsage();
            // Setelah perhitungan avgCpuUsage selesai
            string filePath = @"D:\Skripsi\File\Python\Pengujian\HasilPenggunaanCPUDekripsiCitra.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Penggunaan CPU rata-rata selama dekripsi citra: {avgCpuUsage:F2}% pada {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat menyimpan hasil penggunaan CPU: {ex.Message}");
            }

            // Perbarui status gambar menjadi "Citra hasil dekripsi"
            UpdateImageStatus("Citra Didekripsi");
        }

        private void DecryptImage(string encryptedFilePath, byte[] spritzKey)
        {
            try
            {
                using (FileStream fs = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int width = reader.ReadInt32(); // Membaca lebar gambar
                    int height = reader.ReadInt32(); // Membaca tinggi gambar

                    byte[] encryptedImageData = reader.ReadBytes(width * height);
                    byte[] decryptedImageData = new byte[width * height];

                    progressBarDecryption.Minimum = 0;
                    progressBarDecryption.Maximum = width * height;
                    progressBarDecryption.Value = 0;

                    byte[] keystream = GenerateKeystream(width * height);
                    for (int i = 0; i < encryptedImageData.Length; i++)
                    {
                        decryptedImageData[i] = (byte)(encryptedImageData[i] ^ keystream[i]);
                        progressBarDecryption.Value = i + 1;
                    }

                    Bitmap decryptedImg = new Bitmap(width, height);
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            byte pixelValue = decryptedImageData[y * width + x];
                            decryptedImg.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                        }
                    }

                    pictureBoxPlainImage.Image = decryptedImg;
                    pictureBoxPlainImage.SizeMode = PictureBoxSizeMode.Zoom;
                    MessageBox.Show("Gambar berhasil didekripsi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mendekripsi gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBoxPlainImage.Image == null)
            {
                MessageBox.Show("Tidak ada gambar hasil dekripsi untuk disimpan. Lakukan proses dekripsi terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Menentukan PictureBox yang akan disimpan
            PictureBox pictureBoxToSave = pictureBoxPlainImage;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Citra Medis Decrypted",
                Filter = "JPEG Image (*.jpg;*.jpeg)|*.jpg;*.jpeg",
                Title = "Simpan Gambar Hasil Dekripsi",
                FileName = "plain_image_decrypted.jpg" // Nama default file
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Simpan gambar dari PictureBox ke file dalam format JPEG dengan kualitas 100
                    SaveImageAsJpegWithCompression((Bitmap)pictureBoxToSave.Image, saveFileDialog.FileName, 100L); // Kualitas JPEG 100
                    MessageBox.Show("Gambar berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveImageAsJpegWithCompression(Bitmap image, string path, long quality)
        {
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            //  Menggunakan EncoderParameters untuk mengatur kualitas kompresi JPEG
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters encoderParams = new EncoderParameters(1);
            EncoderParameter encoderParam = new EncoderParameter(myEncoder, quality); // Kualitas JPEG (0-100)
            encoderParams.Param[0] = encoderParam;

            // Simpan gambar dengan kualitas yang diatur
            image.Save(path, jpgEncoder, encoderParams);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            // Jika encoder tidak ditemukan, lempar pengecualian
            throw new InvalidOperationException($"Encoder untuk format {format} tidak ditemukan.");
        }

        // Tombol Reset Key untuk menghapus Spritz Key yang sudah dimuat dan memungkinkan pengguna mengunggah kunci baru
        private void buttonResetKey2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin reset kunci Spritz?", "Konfirmasi Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Mengosongkan spritzKey dan textBoxSpritzKey
                spritzKey = Array.Empty<byte>();
                textBoxSpritzKey.Clear();

                // Mengaktifkan kembali tombol Upload Key dan mengubah warnanya
                buttonUploadKey_Click.Enabled = true;
                buttonUploadKey_Click.BackColor = Color.FromArgb(204, 220, 36);
            }

        }
    }
}
