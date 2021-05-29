using System;

namespace Scrambler.Core.Scramblers
{

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
            var newValue = value + 1;
            if (newValue > maxValue)
                newValue = minValue;
            return newValue;
        }
    }
}