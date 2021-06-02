using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrambler.Core.Scramblers
{

    public interface IScramblerFactory
    {
        bool HandlesType(string scramblerName);
        IScrambler Create(Dictionary<string, object> properties);
    }
}