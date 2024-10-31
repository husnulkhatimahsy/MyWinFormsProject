using System;

public class Spritz
{
    private byte i, j, k, z;  // Elemen dari algoritma
    private byte w;            // Elemen untuk kontrol
    private byte[] S;         // State array

    public Spritz()
    {
        i = j = k = z = 0;     // Inisialisasi elemen
        w = 1;                 // Kontrol untuk i
        S = new byte[256];     // State array berukuran 256
        for (int x = 0; x < 256; x++)
            S[x] = (byte)x;    // Inisialisasi array S
    }

    private void Swap(int x, int y)
    {
        byte temp = S[x];
        S[x] = S[y];
        S[y] = temp;
    }

    public void SetKey(byte[] key)
    {
        if (key == null || key.Length == 0)
        {
            throw new ArgumentException("Kunci tidak valid atau kosong.");
        }

        int keyLength = key.Length;
        byte j = 0;
        for (int i = 0; i < 256; i++)
        {
            j = (byte)((j + S[i] + key[i % keyLength]) % 256);
            Swap(i, j); // Pertukaran elemen dalam S
        }
        this.i = this.j = this.k = this.z = 0;    // Reset state

        // Debug output untuk memastikan kunci diterima dengan benar
        Console.WriteLine("Key set: " + BitConverter.ToString(key));
    }

    public byte[] GenerateKeystream(int length)
    {
        byte[] keystream = new byte[length];
        for (int m = 0; m < length; m++)
        {
            Update();   // Memperbarui nilai i, j, k, z
            keystream[m] = S[(j + S[(i + S[(z + k) % 256]) % 256]) % 256];
        }

        // Tambahkan log untuk memeriksa keystream
        Console.WriteLine("Keystream generated: " + BitConverter.ToString(keystream));

        return keystream;
    }

    private void Update()
    {
        i = (byte)((i + w) % 256);
        j = (byte)((k + S[(j + S[i]) % 256]) % 256);
        k = (byte)((k + i + S[j]) % 256);
        Swap(i, j);
    }
}
