using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public interface IMaskSet
    {
        string ConnectionString { get; }
        IEnumerable<IMaskedCollection> MaskedCollections { get; set; }
    }
}