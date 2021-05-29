using System;
using Scrambler.Core.Scramblers;
using Xunit;

namespace Core.Tests
{
    public class NumberScramblerTests
    {
        [Fact]
        public void TestScrambleChangesValue()
        {
            int currentValue = 10;
            const int minValue = 0;
            const int maxValue = 10;
            var scrambler = new NumberScrambler(minValue, maxValue);
            var newValue = scrambler.Scramble(currentValue);
            Assert.NotEqual(currentValue, newValue);
        }

        [Fact]
        public void TestWithOnlyTwoPossibleValuesVAlueFlips()
        {
            int currentValue = 1;
            const int minValue = 0;
            const int maxValue = 1;
            var scrambler = new NumberScrambler(minValue, maxValue);
            currentValue = scrambler.Scramble(currentValue);
            Assert.Equal(0, currentValue);
            currentValue = scrambler.Scramble(currentValue);
            Assert.Equal(1, currentValue);
        }
    }
}
