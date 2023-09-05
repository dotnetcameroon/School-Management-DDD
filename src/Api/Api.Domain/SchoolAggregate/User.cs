using Api.Domain.Common.Models;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.SchoolAggregate;

public abstract class User : Entity<UserId>
{
    protected readonly List<SchoolClass> _classes = new();
    public IReadOnlyList<SchoolClass> Classes => _classes.AsReadOnly();
    public string? FirstName { get; }
    public string LastName { get; }
    public Password Password { get; private set; }
    public string Role { get; protected set; }
    protected User(
        UserId id,
        string? firstName,
        string lastName,
        Password password,
        string role) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Role = role;
    }
}
