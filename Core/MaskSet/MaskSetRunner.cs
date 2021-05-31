using Scrambled.Core.Persistance;
using Scrambler.Core.Scramblers;

namespace Scramblers.Core.MaskSet
{
    public class MaskSetRunner : IMaskSetRunner
    {
        private readonly MaskSet maskSet;
        private readonly IMaskPersistor maskSetPersistor;

        public MaskSetRunner(MaskSet maskSet, IMaskPersistor maskSetPersistor)
        {
            this.maskSet = maskSet;
            this.maskSetPersistor = maskSetPersistor;
        }
        public void Run()
        {
            foreach (var m in maskSet.MaskedCollections)
            {
                foreach (var p in m.MaskedProperties)
                {
                    //TODO Switch To Enum
                    //Switch Creation Out TO Factory                
                    if (p.MaskType == "StringDictionary")
                    {
                        var scrambler = new StringDictionaryScrambler(new[] { "Hello", "World" });
                        var pValue = (string)maskSetPersistor.GetProperty(p.PropertyName);
                        pValue = scrambler.Scramble(pValue);
                        maskSetPersistor.SetProperty(p.PropertyName, pValue);
                    }
                }
            }
        }
    }
}