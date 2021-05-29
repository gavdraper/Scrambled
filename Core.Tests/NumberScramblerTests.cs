using System;
using Xunit;

namespace Core.Tests
{

    public interface IScrambler<T>
    {
        T Scramble(T value);
    }

    public class NumberScrambler : IScrambler<Int64>
    {
        private readonly long minValue;
        private readonly long maxValue;

        public NumberScrambler(Int64 MinValue, Int64 MaxValue)
        {
            minValue = MinValue;
            maxValue = MaxValue;
        }
        public Int64 Scramble(Int64 value)
        {
            return value + 1;
        }
    }

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
            var newValue = scrambler.Scramble(currentValue);
            Assert.NotEqual(currentValue, newValue);
            newValue = scrambler.Scramble(currentValue);
            Assert.Equal(currentValue, newValue);
        }
    }


}
