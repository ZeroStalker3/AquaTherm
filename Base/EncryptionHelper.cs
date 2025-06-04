using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private const int Key = 7; // ключ шифрования

    // Шифрует строку так, чтобы длина не изменилась
    public static string EncryptPreserve(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        StringBuilder result = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            // Если символ в пределах печатных ASCII (от 32 до 126)
            if (c >= 32 && c <= 126)
            {
                // Применяем сдвиг по модулю 95 (количество печатных символов)
                char encryptedChar = (char)(((c - 32 + Key) % 95) + 32);
                result.Append(encryptedChar);
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    // Дешифрует строку, выполненную методом EncryptPreserve
    public static string DecryptPreserve(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        StringBuilder result = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            if (c >= 32 && c <= 126)
            {
                char decryptedChar = (char)(((c - 32 - Key + 95) % 95) + 32);
                result.Append(decryptedChar);
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
}