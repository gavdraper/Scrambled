using Scrambled.Core.Persistance;
using Scrambler.Core.Scramblers;
using System.Collections.Generic;
using System.Linq;

namespace Scramblers.Core.MaskSet
{
    public class MaskSetRunner : IMaskSetRunner
    {
        private readonly MaskSet maskSet;
        private readonly IMaskPersistor maskSetPersistor;
        private readonly IEnumerable<IScramblerFactory> scramblerFactories;

        public MaskSetRunner(
            MaskSet maskSet,
            IMaskPersistor maskSetPersistor,
            IEnumerable<IScramblerFactory> scramblerFactories)
        {
            this.maskSet = maskSet;
            this.maskSetPersistor = maskSetPersistor;
            this.scramblerFactories = scramblerFactories;
        }

        public void Run()
        {
            foreach (var m in maskSet.MaskedCollections)
            {
                maskCollection(m);
            }
        }

        private void maskCollection(MaskedCollection collection)
        {
            foreach (var p in collection.MaskedProperties)
            {
                scrambleProperty(p);
            }
        }

        private void scrambleProperty(MaskedProperty maskedProperty)
        {
            /* TODO : Switch To Factory For Creation 
                   Something like below should work....

               foreach (var s in scramblers)
               {
                   if (s.HandlesType(maskedProperty.MaskType))
                   {
                       var scrambler = s.CreateScrambler(maskedProperty.Params);
                       //We could probably also have a type specific runner to generalise the below
                       var value = scrambler.Scramble((string)maskSetPersistor.GetProperty(maskedProperty.PropertyName));
                       maskSetPersistor.SetProperty(maskedProperty.PropertyName, value);
                   }
               }
               */


            //TODO : Remove in Favor Of The Above
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