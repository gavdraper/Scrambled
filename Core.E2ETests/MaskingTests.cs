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
        // Will fail, currently used to flesh out what the API surface could feel like to use
        [Fact]
        public void CanMaskDataBasedOnMaskSet()
        {
            /*
                Doesn't Feel Right that ConectionString and CollectionName
                are not needed for InMemory Dictionary Provider. This provider
                is really just for testing though so perhaps will keep as is...
            */
            var myData = new Dictionary<string, string>(){
                {"FieldOne","Hello"},
                {"FieldTwo","World"}
            };

            var maskedPropertyDefinitions = new List<IMaskedProperty>(){
                new MaskedProperty(){
                    PropertyName = "FieldOne",
                    MaskType = "StringDictionary"
                },
                new MaskedProperty(){
                    PropertyName = "FieldTwo",
                    MaskType = "StringDictionary"
                },
            };

            var maskedCollections = new List<IMaskedCollection>(){
                    new MaskedCollection("main",  maskedPropertyDefinitions)
            };

            var maskSet = new MaskSet("local:\\Dictionary", maskedCollections);
            IMaskPersistor maskPersister = new InMemoryDictionaryPersistor(myData);
            IMaskSetRunner maskSetRunner = new MaskSetRunner(maskSet, maskPersister);
            maskSetRunner.Run();

            Assert.Equal("World", myData["FieldOne"]);
            Assert.Equal("Hello", myData["FieldTwo"]);
        }
    }



}
