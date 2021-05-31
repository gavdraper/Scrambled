using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public interface IMaskedProperty
    {
        string PropertyName { get; set; }
        string MaskType { get; set; }
        Dictionary<string, object> Params { get; set; }
    }
}