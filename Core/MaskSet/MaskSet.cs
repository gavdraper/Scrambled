using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
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
}