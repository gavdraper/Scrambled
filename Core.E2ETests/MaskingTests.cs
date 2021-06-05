using System;
using System.Collections.Generic;
using Xunit;
using Scrambler.Core.Scramblers;
using Scramblers.Core.MaskSet;
using Scrambled.Core.Persistance;
//using Scrambled.Persistance.Providers;
using Moq;

namespace Core.E2ETests
{
    public class MaskingTests
    {
        [Fact]
        public void CanMaskDataBasedOnMaskSet()
        {
            var data = createSmallDataSet();
            var maskSet = createSmallMaskSet();
            IMaskSetRunner maskSetRunner = new MaskSetRunner(maskSet, getScramblerFactories());
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

            //Todo Setup SetProperty Method 
            var mockPersistor = new Mock<IMaskPersistor>();
            mockPersistor.Setup(p => p.HandlesType(It.IsAny<string>())).Returns(true);
            mockPersistor.Setup(p => p.GetProperty("FieldOne")).Returns("Hello");
            mockPersistor.Setup(p => p.GetProperty("FieldTwo")).Returns("World");
            mockPersistor.Setup(p => p.GetProperty("FieldThree")).Returns(1);

            var persistors = new IMaskPersistor[] {
               mockPersistor.Object
             };
            return new MaskSet(new MaskPersistanceFactory(persistors), "TestSource", "TestConnection", maskedCollections);
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
