using Api.Domain.Common.Utilities;

namespace DomainTests.Utilities;

public class HashEngineTest
{
    [Theory]
    [InlineData(true, "password!", "password!")]
    [InlineData(true, "password! ow", "password! ow")]
    [InlineData(false, "Password!", "password!")]
    public void GeneratedHashes_ShouldBeEqualsForEqualInputs(bool expected, string firstClearText, string secondClearText)
    {
        var firstHash = HashGenerator.Hash(firstClearText);
        var secondHash = HashGenerator.Hash(secondClearText);

        Assert.Equal(expected, firstHash == secondHash);
    }
}
