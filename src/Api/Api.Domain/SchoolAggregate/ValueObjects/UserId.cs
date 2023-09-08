using System.Text;
using Api.Domain.Common.Models;
using Api.Domain.SchoolAggregate.Exceptions;

namespace Api.Domain.SchoolAggregate.ValueObjects;

public abstract class UserId : ValueObject
{
    protected abstract string Prefix { get; }
    protected const char _separator = '_';
    protected readonly int _year;
    protected readonly string _code;
    protected readonly int _salt;
    public string Value { get; }

    protected UserId(
        string code,
        int year,
        int salt)
    {
        _code = code;
        _year = year;
        _salt = salt;

        Value = new StringBuilder().AppendJoin(
            separator: _separator,
            Prefix,
            _code,
            _year,
            _salt).ToString();

        //Value = $"{Prefix}{_separator}{_code}{_separator}{_year}{_separator}{_salt}";
    }

#pragma warning disable CS8618
    protected UserId()
    {
    }
#pragma warning restore CS8618

    protected static (int year, string code, int salt) Decrypt(string value, string prefix)
    {
        string[] components = value.Split(_separator);
        if (components.Length != 4)
            throw new InvalidIdentifierFormatException();

        if (!components[0].Equals(prefix))
            throw new WrongPrefixException();

        string code = components[1];
        _ = int.TryParse(components[2], out int year);
        _ = int.TryParse(components[3], out int salt);

        return (year, code, salt);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return _code;
        yield return _year;
        yield return _salt;
    }

    public static UserId? Create(string value)
    {
        if (value.StartsWith(TeacherAdvisorId._prefix))
            return TeacherAdvisorId.Create(value);
        else if (value.StartsWith(StudentId._prefix))
            return StudentId.Create(value);
        else
            return AdminId.Create(value);
    }
}
