using System.Collections.Generic;

namespace Scrambler.Core.Scramblers
{
    public class StringDictionaryScramberFactory : IScramblerFactory
    {
        public bool HandlesType(string scramblerName)
        {
            return scramblerName == "StringDictionary";
        }

        public IScrambler Create(Dictionary<string, object> properties)
        {
            return new StringDictionaryScrambler((string[])properties["Dictionary"]);
        }
    }
}