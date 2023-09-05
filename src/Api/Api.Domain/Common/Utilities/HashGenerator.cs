using System.Security.Cryptography;
using System.Text;

namespace Api.Domain.Common.Utilities;

public static class HashGenerator
{
    private const string _salt = "";
    public static string Hash(string data)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(_salt);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        byte[] combinedBytes = new byte[saltBytes.Length + _salt.Length];
        Array.Copy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
        Array.Copy(dataBytes, 0, combinedBytes, 0, dataBytes.Length);

        using var sha256 = SHA256.Create();
        byte[] hashedBytes = sha256.ComputeHash(combinedBytes);
        return Convert.ToBase64String(hashedBytes);
    }
}

