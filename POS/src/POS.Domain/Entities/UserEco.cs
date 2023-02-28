namespace POS.Domain.Entities;

public partial class UserEco : BaseEntity
{
    public string Name { get; set; } = null!;

    public string PaternalLastName { get; set; } = null!;

    public string? MaternalLastName { get; set; }

    public string CellPhone { get; set; } = null!;

    public virtual UserPermission UserPermissions { get; set; } = null!;

    public virtual UserProfile UserProfile { get; set; } = null!;
}
