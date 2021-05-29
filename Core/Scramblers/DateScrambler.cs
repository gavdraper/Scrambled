using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrambler.Core.Scramblers
{

    public class DateScrambler : IScrambler<DateTime>
    {
        private readonly DateTime minValue;
        private readonly DateTime maxValue;

        public DateScrambler(DateTime MinValue, DateTime MaxValue)
        {
            minValue = MinValue.Date;
            maxValue = MaxValue.Date;
        }
        public DateTime Scramble(DateTime value)
        {
            value = value.Date;
            var totalDays = (int)(maxValue - minValue).TotalDays;
            var range =
                Enumerable.Range(0, totalDays + 1)
                .Select(i => minValue.AddDays(i))
                .Where(i => i != value);
            var rand = new System.Random();
            int index = rand.Next(0, totalDays);
            return range.ElementAt(index);
        }
    }
}