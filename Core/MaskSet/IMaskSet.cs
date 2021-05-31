using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public interface IMaskSet
    {
        string ConnectionString { get; }
        List<IMaskedCollection> MaskedCollections { get; set; }
    }
}