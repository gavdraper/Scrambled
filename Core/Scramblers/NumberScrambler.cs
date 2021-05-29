using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrambler.Core.Scramblers
{

    public class NumberScrambler : IScrambler<int>
    {
        private IEnumerable<int> range;

        public NumberScrambler(int minValue, int maxValue)
        {
            range = Enumerable.Range(minValue, maxValue + 1);
        }
        public int Scramble(int value)
        {
            var rand = new System.Random();
            int index = rand.Next(0, range.Count() - 2);
            return range.Where(x => x != value).ElementAt(index);
        }
    }
}