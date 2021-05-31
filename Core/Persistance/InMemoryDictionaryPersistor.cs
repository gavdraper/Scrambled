using System.Collections.Generic;

namespace Scrambled.Core.Persistance
{
    //Todo this needs handle types other than string
    public class InMemoryDictionaryPersistor : IMaskPersistor
    {
        private readonly Dictionary<string, string> data;

        public InMemoryDictionaryPersistor(Dictionary<string, string> data)
        {

            this.data = data;
        }

        public object GetProperty(string propertyName)
        {
            return data[propertyName];
        }

        public void SetProperty(string propertyName, object value)
        {
            data[propertyName] = value.ToString();
        }
    }
}