using System;

public class Spritz
{
    private byte i, j, k, z;
    private byte w;
    private byte[] S;

    public Spritz()
    {
        i = j = k = z = 0;
        w = 1;
        S = new byte[256];
        for (int x = 0; x < 256; x++)
            S[x] = (byte)x;
    }

    private void Swap(int x, int y)
    {
        byte temp = S[x];
        S[x] = S[y];
        S[y] = temp;
    }

    public void SetKey(byte[] key)
    {
        int keyLength = key.Length;
        byte j = 0;
        for (int i = 0; i < 256; i++)
        {
            j = (byte)((j + S[i] + key[i % keyLength]) % 256);
            Swap(i, j);
        }
        this.i = this.j = this.k = this.z = 0;
    }

    public byte[] GenerateKeystream(int length)
    {
        byte[] keystream = new byte[length];
        for (int m = 0; m < length; m++)
        {
            Update();
            keystream[m] = S[(j + S[(i + S[(z + k) % 256]) % 256]) % 256];
        }
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
