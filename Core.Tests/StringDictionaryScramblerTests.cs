using Scrambler.Core.Scramblers;
using Xunit;

namespace Core.Tests
{
    public class StringDictionaryScramblerTests
    {
        [Fact]
        public void TestScrambleChangesValue()
        {
            var words = new string[] { "Hello", "World" };
            var scrambler = new StringDictionaryScrambler(words);
            var currentValue = "Bye";
            var newValue = scrambler.Scramble(currentValue);
            Assert.NotEqual(currentValue, newValue);
        }

        [Fact]
        public void TestWithOnlyTwoPossibleValuesVAlueFlips()
        {
            var words = new string[] { "Hello", "World" };
            var scrambler = new StringDictionaryScrambler(words);
            var currentValue = "Hello";
            currentValue = scrambler.Scramble(currentValue);
            Assert.Equal("World", currentValue);
            currentValue = scrambler.Scramble(currentValue);
            Assert.Equal("Hello", currentValue);
        }
    }

}
