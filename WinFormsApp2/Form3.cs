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

        public Form3()
        {
            InitializeComponent();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Mulai timer untuk menghitung waktu generate kunci
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Generate RSA key pair
                using (var rsa = new RSACng(2048))
                {
                    rsa.KeySize = 2048;
                    publicKey = rsa.ExportParameters(false);
                    privateKey = rsa.ExportParameters(true);

                    // Ekspor kunci ke dalam format PEM
                    textBoxPublicKey.Text = ExportKeyToPEM(publicKey, false);
                    textBoxPrivateKey.Text = ExportKeyToPEM(privateKey, true);

                    // Tampilkan bilangan prima p dan q di TextBox dalam format desimal
                    // Pastikan privateKey.P dan privateKey.Q tidak null sebelum diproses
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

                // Hentikan timer dan tampilkan waktu generate kunci dalam detik
                stopwatch.Stop();
                double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;
                GenerateTime.Text = $"Waktu generate kunci RSA: {elapsedSeconds:F2} detik";
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
                    // Convert the .NET RSAParameters to BouncyCastle RSA parameters
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
    }
}