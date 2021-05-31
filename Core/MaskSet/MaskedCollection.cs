using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public class MaskedCollection : IMaskedCollection
    {
        public string CollectionName { get; set; }
        public IEnumerable<IMaskedProperty> MaskedProperties { get; set; }

        public MaskedCollection(string collectionName, IEnumerable<IMaskedProperty> properties)
        {
            CollectionName = collectionName;
            MaskedProperties = properties;
        }
    }
}