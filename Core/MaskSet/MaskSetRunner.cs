using Scrambled.Core.Persistance;
using Scrambler.Core.Scramblers;
using System.Linq;

namespace Scramblers.Core.MaskSet
{
    public class MaskSetRunner : IMaskSetRunner
    {
        private readonly IMaskSet maskSet;
        private readonly IMaskPersistor maskSetPersistor;

        public MaskSetRunner(IMaskSet maskSet, IMaskPersistor maskSetPersistor)
        {
            this.maskSet = maskSet;
            this.maskSetPersistor = maskSetPersistor;
        }

        public void Run()
        {
            foreach (var m in maskSet.MaskedCollections)
            {
                maskCollection(m);
            }
        }

        private void maskCollection(IMaskedCollection collection)
        {
            foreach (var p in collection.MaskedProperties)
            {
                scrambleProperty(p);
            }
        }

        private void scrambleProperty(IMaskedProperty maskedProperty)
        {
            //TODO Switch MaskType To Enum
            //Switch Creation Out TO Factory   
            if (maskedProperty.MaskType == "StringDictionary")
            {
                var scrambler = new StringDictionaryScrambler(new[] { "Hello", "World" });
                var pValue = (string)maskSetPersistor.GetProperty(maskedProperty.PropertyName);
                pValue = scrambler.Scramble(pValue);
                maskSetPersistor.SetProperty(maskedProperty.PropertyName, pValue);
            }
            else if (maskedProperty.MaskType == "Number")
            {
                var scrambler = new NumberScrambler(
                    (int)maskedProperty.Params["MinValue"],
                    (int)maskedProperty.Params["MaxValue"]);
                var value = (int)maskSetPersistor.GetProperty(maskedProperty.PropertyName);
                value = scrambler.Scramble(value);
                maskSetPersistor.SetProperty(maskedProperty.PropertyName, value);
            }
        }
    }
}