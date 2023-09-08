using Api.Domain.Common.Utilities;

namespace Api.Domain.SchoolAggregate.ValueObjects;

public class AdminId : UserId
{
    private const string _prefix = "Admin";

    public AdminId(
        string code,
        int year,
        int salt) : base(code, year, salt)
    {
    }

    protected override string Prefix => _prefix;
    public static new AdminId? Create(string value)
    {
        var (year, code, salt) = Decrypt(value, _prefix);
        if (year == 0)
            return null;

        return new(code, year, salt);
    }
}
