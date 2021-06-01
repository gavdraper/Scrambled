using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public class MaskSet
    {
        public string ConnectionString { get; }
        public IEnumerable<MaskedCollection> MaskedCollections { get; set; }

        public MaskSet(string connectionString, IEnumerable<MaskedCollection> collections)
        {
            ConnectionString = connectionString;
            MaskedCollections = collections;
        }
    }
}