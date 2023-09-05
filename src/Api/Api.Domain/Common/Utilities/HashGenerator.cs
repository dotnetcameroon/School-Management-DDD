using System.Security.Cryptography;
using System.Text;

namespace Api.Domain.Common.Utilities;

public static class HashGenerator
{
    private const string _salt = "salt_value";
    public static string Hash(string data)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(_salt);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        byte[] combinedBytes = new byte[saltBytes.Length + dataBytes.Length];
        Array.Copy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
        Array.Copy(dataBytes, 0, combinedBytes, 0, dataBytes.Length);
        byte[] hashedBytes = SHA256.HashData(combinedBytes);
        return Convert.ToBase64String(hashedBytes);
    }
}
