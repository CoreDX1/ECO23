namespace POS.Domain.Entities;

public partial class UserEco
{
    public short IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string PaternalLastName { get; set; } = null!;

    public string? MaternalLastName { get; set; }

    public string CellPhone { get; set; } = null!;

    public virtual ICollection<UserPermission> UserPermissions { get; } =
        new List<UserPermission>();

    public virtual ICollection<UserProfile> UserProfiles { get; } = new List<UserProfile>();
}
