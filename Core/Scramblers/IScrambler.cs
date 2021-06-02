using System;

namespace Scrambler.Core.Scramblers
{
    public interface IScrambler
    {
        Object Scramble(Object value);
    }
}