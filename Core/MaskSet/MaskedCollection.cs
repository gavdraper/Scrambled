using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public class MaskedCollection : IMaskedCollection
    {
        public string CollectionName { get; set; }
        public List<IMaskedProperty> MaskedProperties { get; set; }

        public MaskedCollection(string collectionName, List<IMaskedProperty> properties)
        {
            CollectionName = collectionName;
            MaskedProperties = properties;
        }

    }
}