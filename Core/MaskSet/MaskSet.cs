using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public class MaskSet : IMaskSet
    {
        public string ConnectionString { get; }
        public IEnumerable<IMaskedCollection> MaskedCollections { get; set; }

        public MaskSet(string connectionString, IEnumerable<IMaskedCollection> collections)
        {
            ConnectionString = connectionString;
            MaskedCollections = collections;
        }
    }
}