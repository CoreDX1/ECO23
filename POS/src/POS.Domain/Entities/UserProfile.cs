using System.Text.Json.Serialization;

namespace POS.Domain.Entities;

public partial class UserProfile : BaseEntity
{
    public short IdUser { get; set; }

    public short IdLocation { get; set; }

    public string UserPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual UserLocation IdLocationNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual UserEco? UserEco { get; set; }
}
