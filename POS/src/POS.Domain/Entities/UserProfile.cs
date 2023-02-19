using System;
using System.Collections.Generic;

namespace POS.Domain.Entities;

public partial class UserProfile
{
    public short IdUserProfile { get; set; }

    public short IdUser { get; set; }

    public short IdLocation { get; set; }

    public string UserPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual UserLocation IdLocationNavigation { get; set; } = null!;

    public virtual UserEco IdUserNavigation { get; set; } = null!;
}
