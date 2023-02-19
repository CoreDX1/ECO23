﻿using System;
using System.Collections.Generic;

namespace POS.Domain.Entities;

public partial class UserPermission
{
    public short IdUserPermission { get; set; }

    public short IdUserEco { get; set; }

    public short IdUserStatus { get; set; }

    public virtual UserEco IdUserEcoNavigation { get; set; } = null!;

    public virtual UserStatus IdUserStatusNavigation { get; set; } = null!;
}
