using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrambler.Core.Scramblers
{

    public class NumberScrambler : IScrambler
    {
        private IEnumerable<int> range;

        public NumberScrambler(int minValue, int maxValue)
        {
            range = Enumerable.Range(minValue, maxValue + 1);
        }
        public object Scramble(object value)
        {
            var number = (int)value;
            var rand = new System.Random();
            int index = rand.Next(0, range.Count() - 2);
            return range.Where(x => x != number).ElementAt(index);
        }
    }
}