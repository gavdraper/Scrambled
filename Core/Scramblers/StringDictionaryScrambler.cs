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
            var rand = new System.Random();
            int index = rand.Next(0, words.Count() - 2);
            return words.Where(i => i != value).ElementAt(index);
        }
    }
}