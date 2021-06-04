using System;
using System.Collections.Generic;
using Xunit;
using Scrambler.Core.Scramblers;
using Scramblers.Core.MaskSet;
using Scrambled.Core.Persistance;
using Scrambled.Persistance.Providers;

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
            IMaskSetRunner maskSetRunner = new MaskSetRunner(maskSet, maskPersister, getScramblerFactories());
            maskSetRunner.Run();
            Assert.Equal("World", data["FieldOne"]);
            Assert.Equal("Hello", data["FieldTwo"]);
            Assert.NotEqual(1, data["FieldThree"]);
        }

        private IEnumerable<IScramblerFactory> getScramblerFactories()
        {
            return new IScramblerFactory[]
            {
                new NumberScramberFactory(),
                new StringDictionaryScramberFactory()
            };
        }

        private MaskSet createSmallMaskSet()
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

        private IEnumerable<MaskedProperty> createTwoPropertyMasks()
        {
            return new MaskedProperty[]{
                new MaskedProperty(){
                    PropertyName = "FieldOne",
                    MaskType = "StringDictionary",
                    Params = new Dictionary<string,object>{
                        {"Dictionary",new string[]{"Hello","World"}},
                    }
                },
                new MaskedProperty(){
                    PropertyName = "FieldTwo",
                    MaskType = "StringDictionary",
                    Params = new Dictionary<string,object>{
                        {"Dictionary",new string[]{"Hello","World"}},
                    }
                },
                new MaskedProperty(){
                    PropertyName = "FieldThree",
                    MaskType = "Number",
                    Params = new Dictionary<string,object>{
                        {"MinValue",1},
                        {"MaxValue",10}
                    }
                },
            };
        }

        private MaskedCollection[] createEmptyMaskedCollection(IEnumerable<MaskedProperty> maskedPropertyDefinitions)
        {
            return new MaskedCollection[]{
                new MaskedCollection("main",  maskedPropertyDefinitions)
            };
        }

    }
}
