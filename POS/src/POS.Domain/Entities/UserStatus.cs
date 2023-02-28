namespace POS.Domain.Entities;

public partial class UserStatus
{
    public short IdUserStatus { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<UserPermission> UserPermissions { get; } =
        new List<UserPermission>();
}
