using Api.Domain.Common.Models;
using Api.Domain.Common.Utilities;

namespace Api.Domain.Common.ValueObjects;

public class Password : ValueObject
{
    public string Hash { get; set; }

    public Password(string hash)
    {
        Hash = hash;
    }

    public static Password CreateNewPassword(string password)
    {
        string hash = HashGenerator.Hash(password);
        return new(hash);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return Hash;
    }

    public static Password CreateFromHash(string hash)
    {
        return new(hash);
    }
}
