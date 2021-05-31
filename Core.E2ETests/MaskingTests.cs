using System;
using System.Collections.Generic;
using Xunit;
using Scrambler.Core.Scramblers;
using Scramblers.Core.MaskSet;
using Scrambled.Core.Persistance;

namespace Core.E2ETests
{
    public class MaskingTests
    {
        [Fact]
        public void CanMaskDataBasedOnMaskSet()
        {
            var data = createSmallDataSet();
            /*  
                In real world maskSet will be loaded from JSON config files,
                created from a GUI 
            */
            var maskSet = createSmallMaskSet();
            IMaskPersistor maskPersister = new InMemoryDictionaryPersistor(data);
            IMaskSetRunner maskSetRunner = new MaskSetRunner(maskSet, maskPersister);
            maskSetRunner.Run();
            Assert.Equal("World", data["FieldOne"]);
            Assert.Equal("Hello", data["FieldTwo"]);
            Assert.NotEqual(1, data["FieldThree"]);
        }

        private IMaskSet createSmallMaskSet()
        {
            var maskedPropertyDefinitions = createTwoPropertyMasks();
            var maskedCollections = createEmptyMaskedCollection(maskedPropertyDefinitions);
            return new MaskSet("local:\\Dictionary", maskedCollections);
        }

        private Dictionary<string, object> createSmallDataSet()
        {
            return new Dictionary<string, object>(){
                {"FieldOne","Hello"},
                {"FieldTwo","World"},
                {"FieldThree",1}
            };
        }

        private IEnumerable<IMaskedProperty> createTwoPropertyMasks()
        {
            return new IMaskedProperty[]{
                new MaskedProperty(){
                    PropertyName = "FieldOne",
                    MaskType = "StringDictionary",
                },
                new MaskedProperty(){
                    PropertyName = "FieldTwo",
                    MaskType = "StringDictionary"
                },
                new MaskedProperty(){
                    PropertyName = "FieldThree",
                    MaskType = "Number"
                },
            };
        }

        private IMaskedCollection[] createEmptyMaskedCollection(IEnumerable<IMaskedProperty> maskedPropertyDefinitions)
        {
            return new IMaskedCollection[]{
                new MaskedCollection("main",  maskedPropertyDefinitions)
            };
        }

    }
}
