using Api.Domain.Common.ValueObjects;

namespace DomainTests.ValueObjectTests;

public class PasswordTests
{
    [Theory]
    [InlineData(true, "password!", "password!")]
    [InlineData(true, "password! ow", "password! ow")]
    [InlineData(false, "Password!", "password!")]
    public void PasswordHash_Should_Be_Identical_When_Values_Are_The_Same(bool expected, string firstClearText, string secondClearText)
    {
        Password firstPassword = Password.CreateNewPassword(firstClearText);
        Password secondPassword = Password.CreateNewPassword(secondClearText);

        Assert.Equal(expected, firstPassword == secondPassword);
    }
}
