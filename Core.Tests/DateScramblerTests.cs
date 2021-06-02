using System;
using System.Globalization;
using Scrambler.Core.Scramblers;
using Xunit;

namespace Core.Tests
{
    public class DateScramblerTests
    {
        [Fact]
        public void TestScrambleChangesValue()
        {
            DateTime currentValue = DateTime.ParseExact("20210101", "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime minValue = DateTime.ParseExact("20200101", "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime maxValue = DateTime.ParseExact("20220101", "yyyyMMdd", CultureInfo.InvariantCulture);
            var scrambler = new DateScrambler(minValue, maxValue);
            var newValue = scrambler.Scramble(currentValue);
            Assert.NotEqual(currentValue, newValue);
        }

        [Fact]
        public void TestWithOnlyTwoPossibleValuesVAlueFlips()
        {
            DateTime currentValue = DateTime.ParseExact("20210101", "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime minValue = DateTime.ParseExact("20210101", "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime maxValue = DateTime.ParseExact("20210102", "yyyyMMdd", CultureInfo.InvariantCulture);
            var scrambler = new DateScrambler(minValue, maxValue);
            currentValue = (DateTime)scrambler.Scramble(currentValue);
            Assert.Equal(maxValue, currentValue);
            currentValue = (DateTime)scrambler.Scramble(currentValue);
            Assert.Equal(minValue, currentValue);
        }
    }
}
