using System.Collections.Generic;

namespace Scramblers.Core.MaskSet
{
    public class MaskedProperty : IMaskedProperty
    {
        public string PropertyName { get; set; }
        public string MaskType { get; set; }
        public Dictionary<string, object> Params { get; set; }
    }
}