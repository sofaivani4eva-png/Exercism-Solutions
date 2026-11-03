using System;
using System.Linq;

public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        string text = new string(
            plaintext.ToLower()
                .Where(char.IsLetterOrDigit)
                .ToArray()
        );

        if (text.Length == 0)
            return "";

        int c = (int)Math.Ceiling(Math.Sqrt(text.Length));
        int r = (int)Math.Floor(Math.Sqrt(text.Length));

        while (r * c < text.Length || c - r > 1)
        {
            if (r * c < text.Length)
                r++;
            else
                c++;
        }

        string result = "";

        for (int col = 0; col < c; col++)
        {
            if (col > 0)
                result += " ";

            for (int row = 0; row < r; row++)
            {
                int index = row * c + col;

                if (index < text.Length)
                    result += text[index];
                else
                    result += " ";
            }
        }

        return result;
    }
}