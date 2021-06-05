using Scrambled.Core.Persistance;
using Scrambler.Core.Scramblers;
using System.Collections.Generic;
using System.Linq;

namespace Scramblers.Core.MaskSet
{
    public class MaskSetRunner : IMaskSetRunner
    {
        private readonly MaskSet maskSet;
        private readonly IEnumerable<IScramblerFactory> scramblerFactories;

        public MaskSetRunner(
            MaskSet maskSet,
            IEnumerable<IScramblerFactory> scramblerFactories)
        {
            this.maskSet = maskSet;
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
                    var value = scrambler.Scramble(maskSet.MaskPersistance.GetProperty(maskedProperty.PropertyName));
                    maskSet.MaskPersistance.SetProperty(maskedProperty.PropertyName, value);
                }
            }
        }
    }
}