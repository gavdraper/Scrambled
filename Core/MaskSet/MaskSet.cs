using System.Collections.Generic;
using Scrambled.Core.Persistance;

namespace Scramblers.Core.MaskSet
{
    public class MaskSet
    {
        private string MaskSetType { get; }

        public string ConnectionString { get; }

        private IMaskPersistor maskPersistor = null;
        private readonly MaskPersistanceFactory factory;

        public IMaskPersistor MaskPersistance
        {
            get
            {
                if (maskPersistor == null)
                {
                    maskPersistor = factory.Create(MaskSetType);
                }
                return maskPersistor;
            }
        }
        public IEnumerable<MaskedCollection> MaskedCollections { get; set; }
        public string PersistanceType { get; set; }

        public MaskSet(
            MaskPersistanceFactory factory,
            string maskSetType,
            string connectionString,
            IEnumerable<MaskedCollection> collections)
        {
            this.factory = factory;
            MaskSetType = maskSetType;
            ConnectionString = connectionString;
            MaskedCollections = collections;
        }
    }
}