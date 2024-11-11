using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        private RSAParameters publicKey;
        private RSAParameters privateKey;
        private CPUMonitor cpuMonitor; // Inisialisasi CPUMonitor untuk pemantauan CPU

        private Form1 mainForm;

        public Form3(Form1 parentForm) // Konstruktor menerima referensi Form1
        {
            InitializeComponent();
            this.mainForm = parentForm;
            cpuMonitor = new CPUMonitor(); // Inisialisasi CPUMonitor

            comboBoxKeySize.SelectedIndex = 1; // Set default ke 2048
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadImages(); // Panggil metode untuk memuat gambar

            // Cek apakah kunci RSA sudah pernah di-generate
            if (mainForm.rsaKeyGenerated)
            {
                btnGenerate.Enabled = false; // Nonaktifkan tombol Generate
                btnGenerate.BackColor = Color.Gray; // Ubah warna tombol jadi abu-abu

                // Isi TextBox dengan kunci yang sudah ada
                textBoxPublicKey.Text = mainForm.PublicKeyText;
                textBoxPrivateKey.Text = mainForm.PrivateKeyText;
                textBoxPrimaP.Text = mainForm.PrimaP;
                textBoxPrimaQ.Text = mainForm.PrimaQ;
            }

            // Set TextBox to ReadOnly to prevent user input
            textBoxPrimaP.ReadOnly = true;
            textBoxPrimaQ.ReadOnly = true;
            textBoxPublicKey.ReadOnly = true;
            textBoxPrivateKey.ReadOnly = true;
        }

        private void LoadImages()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;

                pictureBoxSave.Image = LoadImage(Path.Combine(basePath, "Resources", "save.png"));
                pictureBoxSave.SizeMode = PictureBoxSizeMode.Zoom;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (mainForm.rsaKeyGenerated)
            {
                MessageBox.Show("Kunci RSA sudah dibangkitkan. Tidak dapat membangkitkan lagi dalam sesi ini.");
                return;
            }

            cpuMonitor.StartMonitoring(); // Mulai pemantauan CPU

            try
            {
                // Pengecekan null sebelum mengambil nilai dari SelectedItem
                if (comboBoxKeySize.SelectedItem == null)
                {
                    MessageBox.Show("Silakan pilih panjang kunci terlebih dahulu.");
                    return;
                }

                // Ambil item yang dipilih dan ekstrak angka dari teks
                string selectedKeySizeText = comboBoxKeySize.SelectedItem?.ToString() ?? "[2048 bit]";
                int keySize = int.Parse(selectedKeySizeText.Split(' ')[0].Trim('[', ']')); // Ekstrak angka dari teks

                // Generate RSA key pair dengan panjang kunci yang dipilih
                using (var rsa = new RSACng(keySize))

                {
                    rsa.KeySize = keySize;
                    publicKey = rsa.ExportParameters(false);
                    privateKey = rsa.ExportParameters(true);

                    // Ekspor kunci ke dalam format PEM
                    textBoxPublicKey.Text = ExportKeyToPEM(publicKey, false);
                    textBoxPrivateKey.Text = ExportKeyToPEM(privateKey, true);

                    // Menampilkan bilangan prima p dan q di TextBox dalam format desimal
                    // Memastikan privateKey.P dan privateKey.Q tidak null sebelum diproses
                    if (privateKey.P != null)
                    {
                        // Konversi byte array ke BigInteger dan tampilkan di TextBox
                        textBoxPrimaP.Text = ByteArrayToPositiveBigInteger(privateKey.P).ToString();
                    }
                    else
                    {
                        // Tampilkan pesan jika P adalah null
                        textBoxPrimaP.Text = "P tidak tersedia";
                    }

                    if (privateKey.Q != null)
                    {
                        // Konversi byte array ke BigInteger dan tampilkan di TextBox
                        textBoxPrimaQ.Text = ByteArrayToPositiveBigInteger(privateKey.Q).ToString();
                    }
                    else
                    {
                        // Tampilkan pesan jika Q adalah null
                        textBoxPrimaQ.Text = "Q tidak tersedia";
                    }
                }

                // Menandai bahwa kunci sudah dibangkitkan
                mainForm.rsaKeyGenerated = true;
                mainForm.PublicKeyText = textBoxPublicKey.Text;
                mainForm.PrivateKeyText = textBoxPrivateKey.Text;
                mainForm.PrimaP = textBoxPrimaP.Text;
                mainForm.PrimaQ = textBoxPrimaQ.Text;

                // Ubah tampilan tombol menjadi tidak aktif
                btnGenerate.Enabled = false;
                btnGenerate.BackColor = Color.Gray; // Ubah warna tombol jadi abu-abu
                MessageBox.Show("Kunci RSA berhasil dibangkitkan.");

                cpuMonitor.StopMonitoring(); // Hentikan pemantauan CPUx

                // Ambil rata-rata penggunaan CPU selama proses pembangkitan kunci RSA
                double avgCpuUsage = cpuMonitor.GetAverageCpuUsage();

                // Setelah perhitungan avgCpuUsage selesai
                string filePath = @"D:\Skripsi\File\Python\Pengujian\HasilPenggunaanCPUPembangkitanKunciRSA.txt";

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine($"Penggunaan CPU rata-rata selama pembangkitan kunci RSA: {avgCpuUsage:F2}% pada {DateTime.Now}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saat menyimpan hasil penggunaan CPU: {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Panggil metode untuk menyimpan kunci otomatis
            SaveKeysToFile(textBoxPublicKey.Text, textBoxPrivateKey.Text);
        }

        private void SaveKeysToFile(string publicKey, string privateKey)
        {
            // Simpan kunci publik
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci RSA",
                Filter = "PEM files|*.pem",
                Title = "Save Public Key",
                FileName = "public_key.pem" // Nama file default untuk kunci publik
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine(publicKey);
                    }

                    MessageBox.Show("Public key berhasil disimpan.");
                }
            }

            // Simpan kunci privat
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\Skripsi\File\Python\Pengujian\Kunci RSA",
                Filter = "PEM files|*.pem",
                Title = "Save Private Key",
                FileName = "private_key.pem" // Nama file default untuk kunci privat
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine(privateKey);
                    }

                    MessageBox.Show("Private key berhasil disimpan.");
                }
            }
        }

        private string ExportKeyToPEM(RSAParameters key, bool includePrivateParameters)
        {
            using (var sw = new StringWriter())
            {
                var pemWriter = new PemWriter(sw);

                if (includePrivateParameters)
                {
                    // Konversi .NET RSAParameters ke BouncyCastle RSA parameters
                    var keyPair = DotNetUtilities.GetRsaKeyPair(key);
                    pemWriter.WriteObject(keyPair.Private);
                }
                else
                {
                    var publicKey = DotNetUtilities.GetRsaPublicKey(key);
                    pemWriter.WriteObject(publicKey);
                }

                pemWriter.Writer.Flush();
                return sw.ToString();
            }
        }

        /*
        public static AsymmetricCipherKeyPair GetRsaKeyPair(RSAParameters parameters)
        {
            RsaPrivateCrtKeyParameters privateKey = new RsaPrivateCrtKeyParameters(
                new Org.BouncyCastle.Math.BigInteger(1, parameters.Modulus),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.Exponent),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.D),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.P),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.Q),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.DP),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.DQ),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.InverseQ));

            RsaKeyParameters publicKey = new RsaKeyParameters(
                false,
                new Org.BouncyCastle.Math.BigInteger(1, parameters.Modulus),
                new Org.BouncyCastle.Math.BigInteger(1, parameters.Exponent));

            return new AsymmetricCipherKeyPair(publicKey, privateKey);
        }
        */

        private BigInteger ByteArrayToPositiveBigInteger(byte[] byteArray)
        {
            // Konversi byte array ke BigInteger
            BigInteger value = new BigInteger(byteArray, isUnsigned: true, isBigEndian: true);

            // Pastikan bilangan adalah positif
            return value < 0 ? value + BigInteger.Pow(2, byteArray.Length * 8) : value;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }



        private void textBoxPrimaP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrimaQ_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}