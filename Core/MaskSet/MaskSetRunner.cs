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
            foreach (var s in scramblerFactories)
            {
                if (s.HandlesType(maskedProperty.MaskType))
                {
                    var scrambler = s.Create(maskedProperty.Params);
                    //We could probably also have a type specific runner to generalise the below
                    var value = scrambler.Scramble(maskSetPersistor.GetProperty(maskedProperty.PropertyName));
                    maskSetPersistor.SetProperty(maskedProperty.PropertyName, value);
                }
            }
        }
    }
}