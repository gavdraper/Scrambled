using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrambler.Core.Scramblers
{

    public class NumberScrambler : IScrambler<int>
    {
        private readonly int minValue;
        private readonly int maxValue;

        public NumberScrambler(int MinValue, int MaxValue)
        {
            minValue = MinValue;
            maxValue = MaxValue;
        }
        public int Scramble(int value)
        {
            var range =
                Enumerable.Range(minValue, maxValue + 1)
                .Where(i => i != value);
            var rand = new System.Random();
            int index = rand.Next(0, range.Count() - 1);
            return range.ElementAt(index);
        }
    }
}