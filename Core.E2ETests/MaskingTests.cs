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
            //Arrange
            var source = new Dictionary<string, object>(){
                {"FieldOne","Hello"},
                {"FieldTwo","World"},
                {"FieldThree",1},
            };
            var mockPersistor = new Mock<IMaskPersistor>();
            mockPersistor.Setup(p => p.HandlesType(It.IsAny<string>())).Returns(true);
            mockPersistor.Setup(p => p.GetProperty(It.IsAny<string>())).Returns((string x) => source[x]);
            mockPersistor.Setup(p => p.SetProperty(It.IsAny<string>(), It.IsAny<object>()))
            .Callback((string key, object value) =>
            {
                source[key] = value;
            });

            var maskSet = createSmallMaskSet(mockPersistor.Object);
            IMaskSetRunner maskSetRunner = new MaskSetRunner(maskSet, getScramblerFactories());

            //Act
            maskSetRunner.Run();

            //Assert
            Assert.Equal("World", source["FieldOne"]);
            Assert.Equal("Hello", source["FieldTwo"]);
            Assert.NotEqual(1, source["FieldThree"]);
        }

        private IEnumerable<IScramblerFactory> getScramblerFactories()
        {
            return new IScramblerFactory[]
            {
                new NumberScramberFactory(),
                new StringDictionaryScramberFactory()
            };
        }

        private MaskSet createSmallMaskSet(IMaskPersistor persistor)
        {
            var maskedPropertyDefinitions = createTwoPropertyMasks();
            var maskedCollections = createEmptyMaskedCollection(maskedPropertyDefinitions);
            var persistors = new IMaskPersistor[] {
               persistor
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
