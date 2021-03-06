using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrambler.Core.Scramblers
{

    public class DateScrambler : IScrambler
    {
        private int totalDays;
        private IEnumerable<DateTime> dateRange;

        public DateScrambler(DateTime minValue, DateTime maxValue)
        {
            totalDays = (int)(maxValue - minValue).TotalDays;
            dateRange =
                Enumerable.Range(0, totalDays + 1)
                .Select(i => minValue.AddDays(i));
        }
        public Object Scramble(Object value)
        {
            var date = (DateTime)value;
            var rand = new System.Random();
            int index = rand.Next(0, totalDays);
            return dateRange.Where(x => x.Date != date.Date).ElementAt(index);
        }
    }
}