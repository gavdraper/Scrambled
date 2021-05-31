namespace Scrambled.Core.Persistance
{
    public interface IMaskPersistor
    {
        object GetProperty(string propertyName);
        void SetProperty(string propertyName, object value);
    }
}