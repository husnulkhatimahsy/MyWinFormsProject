using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WinFormsApp2;

namespace WinFormsApp2
{
    public partial class Form5 : Form
    {
        // Deklarasi spritzKey sebagai array byte
        private byte[] spritzKey;
        // Deklarasi variabel decryptedSpritzKey sebagai array byte
        private byte[]? decryptedSpritzKey;

        public Form5()
        {
            InitializeComponent();
            spritzKey = Array.Empty<byte>(); // Inisialisasi dengan array kosong
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
                double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds; // Mengambil waktu dalam detik

                // Menampilkan waktu dekripsi
                lblDecryptionTime2.Text = $"Waktu Dekripsi: {elapsedTimeInSeconds} detik";

                // Update progress bar (diatur ke 100% jika proses dekripsi berhasil)
                progressBarDecryption2.Value = 100;

                // Menyimpan kunci Spritz yang telah didekripsi untuk digunakan di bagian lain dari program
                decryptedSpritzKey = spritzKey;

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

        private void btnSaveSpritzKey_Click(object sender, EventArgs e)
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
        }

        private void buttonChooseImage_Click_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Citra Medis Encrypted",
                Filter = "File Gambar (*.bmp) | *.bmp",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textBoxCipherImagePath.Text = filePath;
                pictureBoxCipherImage.Image = Image.FromFile(filePath);
                pictureBoxCipherImage.SizeMode = PictureBoxSizeMode.Zoom;
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci Spritz Decrypted",
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memuat kunci Spritz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            // Menggunakan Stopwatch untuk mengukur waktu dekripsi
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // Mulai mengukur waktu

            // Dekripsi gambar
            DecryptImage(cipherImagePath, spritzKey);

            stopwatch.Stop(); // Hentikan pengukuran waktu
            double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds; // Mengambil waktu dalam detik

            labelDecryptionTime.Text = $"Waktu Dekripsi: {elapsedTimeInSeconds} detik";

        }

        private void DecryptImage(string imagePath, byte[] spritzKey)
        {
            try
            {
                using (Bitmap encryptedImg = new Bitmap(imagePath))
                {
                    int width = encryptedImg.Width;
                    int height = encryptedImg.Height;
                    byte[] encryptedImageData = new byte[width * height];
                    byte[] decryptedImageData = new byte[width * height];

                    // Inisialisasi progress bar
                    progressBarDecryption.Minimum = 0;
                    progressBarDecryption.Maximum = height * width;
                    progressBarDecryption.Value = 0;

                    // Membaca data gambar terenkripsi
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixelColor = encryptedImg.GetPixel(x, y);
                            encryptedImageData[y * width + x] = pixelColor.R; // Gambar grayscale jadi hanya R yang diambil
                        }
                    }

                    // Mendekripsi data gambar
                    byte[] keystream = GenerateKeystream(width * height);
                    for (int i = 0; i < encryptedImageData.Length; i++)
                    {
                        decryptedImageData[i] = (byte)(encryptedImageData[i] ^ keystream[i]);

                        // Update progress bar
                        progressBarDecryption.Value = i + 1;
                    }

                    // Simpan gambar terdekripsi
                    Bitmap decryptedImg = new Bitmap(width, height);
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            byte pixelValue = decryptedImageData[y * width + x];
                            decryptedImg.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                        }
                    }

                    // Tampilkan gambar terdekripsi di PictureBox
                    pictureBoxPlainImage.Image = decryptedImg;
                    pictureBoxPlainImage.SizeMode = PictureBoxSizeMode.Zoom;

                    MessageBox.Show("Gambar berhasil didekripsi. Silakan simpan gambar terdekripsi menggunakan tombol 'Save Citra Medis'.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mendekripsi gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GenerateKeystream(int length)
        {
            Spritz spritz = new Spritz();
            spritz.SetKey(spritzKey);
            return spritz.GenerateKeystream(length); // Menghasilkan keystream sepanjang 'length'
        }


        private void button8_Click(object sender, EventArgs e)
        {
            // Tentukan PictureBox yang akan disimpan
            PictureBox pictureBoxToSave = pictureBoxPlainImage; // Atur sesuai dengan PictureBox yang diinginkan

            // Tentukan format file dan filter dialog
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
                    // Simpan gambar dari PictureBox ke file dalam format JPEG
                    pictureBoxToSave.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Gambar berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan gambar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
