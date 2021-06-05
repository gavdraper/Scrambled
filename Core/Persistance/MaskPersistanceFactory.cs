namespace Scrambled.Core.Persistance
{

    public interface IMaskPersistanceFactory
    {
        IMaskPersistor Create(string type);
    }

    public class MaskPersistanceFactory : IMaskPersistanceFactory
    {
        IMaskPersistor[] persistors;
        public MaskPersistanceFactory(IMaskPersistor[] persistors)
        {
            this.persistors = persistors;
        }
        public IMaskPersistor Create(string type)
        {
            foreach (var p in persistors)
            {
                if (p.HandlesType(type))
                {
                    return p;
                }
            }
            return null;
        }
    }
}