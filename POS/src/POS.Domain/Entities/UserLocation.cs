using System.Text.Json.Serialization;

namespace POS.Domain.Entities;

public partial class UserLocation
{
    public short IdLocation { get; set; }

    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    public short IdProvince { get; set; }

    public virtual Province IdProvinceNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<UserProfile> UserProfiles { get; } = new List<UserProfile>();
}
