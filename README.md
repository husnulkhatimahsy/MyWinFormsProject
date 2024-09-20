# MyWinFormsProject - Hybrid Cryptosystem with Spritz and RSA for Medical Image Security

### Deskripsi
Proyek ini mengimplementasikan **Hybrid Cryptosystem** dengan menggabungkan algoritma **Spritz** dan **RSA** untuk mengenkripsi dan melindungi citra medis. Pendekatan ini memanfaatkan algoritma stream cipher **Spritz** untuk enkripsi data yang cepat dan **RSA** untuk keamanan enkripsi kunci.

### Tujuan
Tujuan dari proyek ini adalah untuk meningkatkan keamanan dalam pengiriman citra medis, mengurangi risiko pencurian atau manipulasi data selama proses transmisi.

### Fitur Utama
- **RSA Key Pair Generation**: Menghasilkan kunci publik dan privat menggunakan algoritma RSA (2048 bit).
- **Spritz Encryption**: Menggunakan algoritma Spritz untuk mengenkripsi citra medis secara efisien.
- **Hybrid Encryption**: Menggabungkan RSA untuk enkripsi kunci Spritz dan Spritz untuk enkripsi data citra.
- **User Interface**: Aplikasi berbasis GUI menggunakan Windows Forms untuk mempermudah penggunaan.
- **Error Handling**: Validasi dan penanganan kesalahan yang baik selama operasi pemuatan kunci dan enkripsi.

### Instalasi dan Penggunaan
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/husnulkhatimahsy/MyWinFormsProject.git
2. **Buka Proyek di Visual Studio**:
   Pastikan Anda menggunakan Visual Studio dengan dukungan untuk proyek Windows Forms.
3. **Build dan Jalankan Aplikasi**:
Setelah terbuka di Visual Studio, lakukan Build pada proyek dan jalankan aplikasi.

### Petunjuk Penggunaan
#### Penyimpanan di Perangkat:
- Pengirim bertanggung jawab untuk menyimpan citra medis terenkripsi di perangkat.
- Pengirim memulai dengan memilih file citra medis, membangkitkan kunci simetris **Spritz**, dan mengenkripsi citra medis.
- Citra medis yang terenkripsi disimpan di perangkat untuk penggunaan lebih lanjut. Tidak perlu mengirimkan citra kepada penerima.

#### Pengiriman ke Receiver:
- Pengirim bertanggung jawab untuk mengenkripsi citra medis sebelum mengirimkannya ke penerima.
- Pengirim memulai dengan memilih file citra medis, kemudian membangkitkan kunci simetris **Spritz**.
- Citra medis dienkripsi menggunakan algoritma **Spritz**, menghasilkan **cipher image**.
- Setelah itu, kunci simetris **Spritz** dienkripsi menggunakan kunci publik **RSA** yang diberikan oleh penerima.
- **Cipher image** dan **cipher key** kemudian dikirimkan kepada penerima melalui media yang aman.

#### Dekripsi oleh Penerima:
- Penerima bertanggung jawab untuk menerima dan mendekripsi citra medis.
- Penerima memulai dengan membangkitkan pasangan kunci **RSA**, terdiri dari kunci publik dan kunci privat.
- Setelah membangkitkan kunci, penerima membagikan kunci publiknya kepada pengirim.
- Kemudian, penerima menerima **cipher image** dan **cipher key** dari pengirim melalui media yang aman.
- Penerima menggunakan kunci privat **RSA** untuk mendekripsi **cipher key**, menghasilkan kunci simetris **Spritz** yang digunakan untuk enkripsi citra medis.
- Setelah memperoleh kunci simetris tersebut, penerima melanjutkan dengan mendekripsi **cipher image** menggunakan kunci simetris **Spritz** yang diperoleh, sehingga citra medis asli dapat dipulihkan dan diakses.

### Dependencies
Proyek ini menggunakan beberapa dependencies eksternal, di antaranya:
- BouncyCastle: Untuk mengelola operasi kriptografi seperti pemrosesan kunci RSA.
- Windows Forms: Antarmuka pengguna berbasis GUI untuk pengelolaan kunci dan citra medis.

### Cara Menginstal Dependencies
BouncyCastle dapat ditambahkan melalui NuGet Package Manager di Visual Studio:
- Buka Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
- Cari BouncyCastle dan klik Install.

### Struktur Proyek
Berikut adalah struktur proyek beserta deskripsi singkat dari masing-masing file:
- **Form1.cs**: Main application form, entry point untuk operasi enkripsi dan dekripsi citra.
- **Form2.cs**: menyediakan informasi tentang instruksi penggunaan.
- **Form3.cs**: Menampilkan bilangan prima dari kunci RSA dan menghasilkan pasangan kunci RSA (kunci publik dan kunci privat).
- **Form4.cs**: Memproses enkripsi citra dengan kunci Spritz dan enkripsi kunci Spritz dengan kunci publik RSA
- **Form5.cs**: Mendekripsi kunci yang dienkripsi dan mengelola dekripsi citra.
- **Spritz.cs**: Implementasi algoritma Spritz untuk stream cipher.
- **SplashScreen.cs**: Tampilan awal yang muncul sementara sebelum aplikasi utama dimuat dan ditampilkan sepenuhnya.
