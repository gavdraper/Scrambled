using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public interface IMaskedCollection
    {
        string CollectionName { get; }
        IEnumerable<IMaskedProperty> MaskedProperties { get; set; }
    }
}