using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace TNE.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        [EnumMember(Value = "InWork")]
        InWork = 1,
        [EnumMember(Value = "InStorage")]
        InStorage = 0,
        [EnumMember(Value = "UnderRepair")]
        UnderRepair = 2,
        [EnumMember(Value = "Dismiss")]
        Dismiss = 3
    }
}
