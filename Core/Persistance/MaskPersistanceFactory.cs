namespace Scrambled.Core.Persistance
{

    public interface IMaskPersistanceFactory
    {
        IMaskPersistor Create(string type);
    }

    public class MaskPersistanceFactory : IMaskPersistanceFactory
    {
        public IMaskPersistor Create(string type)
        {
            if (type == "InMemoryDictionary")
            {
                return new InMemoryDictionaryPersistor(null);
            }
            return null;
        }
    }
}