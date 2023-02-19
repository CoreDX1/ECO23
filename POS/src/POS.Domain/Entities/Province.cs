using System;
using System.Collections.Generic;

namespace POS.Domain.Entities;

public partial class Province
{
    public short IdProvince { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserLocation> UserLocations { get; } = new List<UserLocation>();
}
