using System;
using System.Collections.Generic;
using Xunit;
using Scrambler.Core.Scramblers;


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


            //Todo need some sort of ITterator to aggregate multiple types of IScrambler
            List<IScrambler<string>> stringScramblers = new List<IScrambler<string>>();
            stringScramblers.Add(new StringDictionaryScrambler(new string[] { "Hello", "World" }));

            var myData = new Dictionary<string, string>(){
                {"FieldOne","Hello"},
                {"FieldTwo","World"}
            };

            var maskedPropertyDefinitions = new List<IMaskedProperty>(){
                new MaskedProperty(){
                    PropertyName = "FieldOne",
                    MaskType = "StringDictionary"
                }
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

    public interface IMaskPersistor { }
    public interface IMaskSetRunner
    {
        void Run();
    }

    public class InMemoryDictionaryPersistor : IMaskPersistor
    {
        private readonly Dictionary<string, string> data;

        public InMemoryDictionaryPersistor(Dictionary<string, string> data)
        {

            this.data = data;
        }
    }
    public class MaskSetRunner : IMaskSetRunner
    {
        public MaskSetRunner(MaskSet maskSet, IMaskPersistor maskSetPersistor) { }
        public void Run() { }
    }

    public interface IMaskSet
    {
        string ConnectionString { get; }
        List<IMaskedCollection> MaskedCollections { get; set; }
    }
    public class MaskSet : IMaskSet
    {
        public string ConnectionString { get; }
        public List<IMaskedCollection> MaskedCollections { get; set; }

        public MaskSet(string connectionString, List<IMaskedCollection> collections)
        {
            ConnectionString = connectionString;
            MaskedCollections = collections;
        }
    }

    public interface IMaskedCollection
    {
        string CollectionName { get; }
    }
    public class MaskedCollection : IMaskedCollection
    {
        public string CollectionName { get; set; }
        public List<IMaskedProperty> MaskedProperties { get; set; }

        public MaskedCollection(string collectionName, List<IMaskedProperty> properties)
        {
            CollectionName = collectionName;
            MaskedProperties = properties;
        }

    }

    public interface IMaskedProperty
    {
        string PropertyName { get; set; }
        string MaskType { get; set; }
    }

    public class MaskedProperty : IMaskedProperty
    {
        public string PropertyName { get; set; }
        public string MaskType { get; set; }
    }
}
