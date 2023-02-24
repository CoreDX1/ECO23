using System.Text.Json.Serialization;

namespace POS.Domain.Entities;

public partial class Province
{
    public short IdProvince { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<UserLocation> UserLocations { get; } = new List<UserLocation>();
}
