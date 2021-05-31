using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public interface IMaskedCollection
    {
        string CollectionName { get; }
        List<IMaskedProperty> MaskedProperties { get; set; }
    }
}