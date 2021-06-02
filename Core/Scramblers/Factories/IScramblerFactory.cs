using System.Collections.Generic;

namespace Scrambler.Core.Scramblers
{
    public interface IScramblerFactory
    {
        bool HandlesType(string scramblerName);
        IScrambler Create(Dictionary<string, object> properties);
    }
}