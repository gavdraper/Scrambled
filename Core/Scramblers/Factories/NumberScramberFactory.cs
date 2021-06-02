using System.Collections.Generic;

namespace Scrambler.Core.Scramblers
{
    public class NumberScramberFactory : IScramblerFactory
    {
        public bool HandlesType(string scramblerName)
        {
            return scramblerName == "Number";
        }

        public IScrambler Create(Dictionary<string, object> properties)
        {
            return new NumberScrambler((int)properties["MinValue"], (int)properties["MaxValue"]);
        }
    }
}