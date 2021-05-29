namespace Scrambler.Core.Scramblers
{
    public interface IScrambler<T>
    {
        T Scramble(T value);
    }
}