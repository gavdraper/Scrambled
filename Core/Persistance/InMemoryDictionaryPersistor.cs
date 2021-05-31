using System.Collections.Generic;

namespace Scrambled.Core.Persistance
{
    //Todo this needs handle types other than string
    public class InMemoryDictionaryPersistor : IMaskPersistor
    {
        private readonly Dictionary<string, object> data;

        public InMemoryDictionaryPersistor(Dictionary<string, object> data)
        {
            this.data = data;
        }

        public object GetProperty(string propertyName)
        {
            return data[propertyName];
        }

        public Dictionary<string, object> GetProperties()
        {
            return data;
        }

        public void SetProperty(string propertyName, object value)
        {
            data[propertyName] = value.ToString();
        }
    }
}