using Xunit;
using BoringHelpers.Collections;

namespace BoringHelpersTests.Collections
{
    public class Enumerable
    {
        [Fact]
        public void Empty_HasNone() => Assert.Empty(Empty.Enumerable<string>());

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Single_HasOne(int input) => Assert.Single(Individual.Enumerable(input), input);
    }
}
