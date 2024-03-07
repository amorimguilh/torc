using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Torc.API.Repositories.Domain.Enums;

public enum Category
{
    Fiction,
    [EnumMember(Value = "Non-Fiction")]
    NonFiction,
    Mistery,
    Biography,
    [EnumMember(Value = "Sci-Fi")]
    SciFi
}
