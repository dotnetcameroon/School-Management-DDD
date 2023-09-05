namespace Api.Domain.Common.Utilities;

public class RandomCodeGenerator
{
    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string GetRandomCode(int length)
    {
        return new string(
            Enumerable
                .Repeat(chars, length)
                .Select(s => s[Random.Shared.Next(s.Length)])
                .ToArray());
    }
}
