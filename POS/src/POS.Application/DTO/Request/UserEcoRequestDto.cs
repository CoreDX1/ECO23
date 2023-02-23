using POS.Utilities.Static;

namespace POS.Application.DTO.Request;

public class UserEcoRequestDto
{
    // TODO : User Table //
    public string Name { get; set; } = null!;
    public string PaternalLastName { get; set; } = null!;
    public string? MaternalLastName { get; set; }
    public string CellPhone { get; set; } = null!;
    public short IdUserProfile { get; set; }

    // TODO : Localidad Tab //
    public short IdLocation { get; set; }
    public string Street { get; set; } = null!;
    public int HouseNumber { get; set; }
    public ProvinceEnum IdProvince { get; set; }

    // TODO : Profile Table //
    public string UserPassword { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreationDate { get; } = DateTime.Now;
}
