using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public class MaskedCollection
    {
        public string CollectionName { get; set; }
        public IEnumerable<MaskedProperty> MaskedProperties { get; set; }

        public MaskedCollection(string collectionName, IEnumerable<MaskedProperty> properties)
        {
            CollectionName = collectionName;
            MaskedProperties = properties;
        }
    }
}