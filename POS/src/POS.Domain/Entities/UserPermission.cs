using System.Text.Json.Serialization;

namespace POS.Domain.Entities;

public partial class UserPermission
{
    public short IdUserPermission { get; set; }

    public short IdUserEco { get; set; }

    public short IdUserStatus { get; set; }

    [JsonIgnore]
    public virtual UserEco IdUserEcoNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual UserStatus IdUserStatusNavigation { get; set; } = null!;
}
