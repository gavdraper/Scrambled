using System.Collections.Generic;
using Scrambled.Core.Persistance;

namespace Scramblers.Core.MaskSet
{
    public class MaskSet
    {
        private string MaskSetType { get; }

        public string ConnectionString { get; }

        private IMaskPersistor maskPersistor = null;
        public IMaskPersistor MaskPersistance
        {
            get
            {
                if (maskPersistor == null)
                {
                    IMaskPersistanceFactory creator = new MaskPersistanceFactory();
                    maskPersistor = creator.Create(MaskSetType);
                }
                return maskPersistor;
            }
        }
        public IEnumerable<MaskedCollection> MaskedCollections { get; set; }
        public string PersistanceType { get; set; }

        public MaskSet(
            string maskSetType,
            string connectionString,
            IEnumerable<MaskedCollection> collections)
        {
            MaskSetType = maskSetType;
            ConnectionString = connectionString;
            MaskedCollections = collections;
        }
    }
}