using System.Collections.Generic;
using System.Linq;

namespace Scrambler.Core.Scramblers
{
    public class StringDictionaryScrambler : IScrambler<string>
    {
        private readonly string[] words;

        public StringDictionaryScrambler(string[] words)
        {
            this.words = words;
        }
        public string Scramble(string value)
        {
            var range = words.Where(i => i != value);
            var rand = new System.Random();
            int index = rand.Next(0, range.Count() - 1);
            return range.ElementAt(index);
        }
    }
}