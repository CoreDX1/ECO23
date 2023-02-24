namespace POS.Application.DTO.Request;

public class UserEcoRequestDto
{
    // INFO : Profile Table //
    public string? UserPassword { get; set; }
    public string? Email { get; set; }
    public DateTime CreationDate { get; set; }

    // INFO : User Table //
    public string? Name { get; set; }
    public string? PaternalLastName { get; set; }
    public string? MaternalLastName { get; set; }
    public string? CellPhone { get; set; }
    public short IdUserProfile { get; set; }

    // INFO : Localidad Table //
    public string? Street { get; set; }
    public int HouseNumber { get; set; }
    public short IdProvince { get; set; }
}
