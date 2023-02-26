using System.Text.Json.Serialization;
using POS.Utilities.Static;

namespace POS.Application.DTO.Request;

public class UserEcoRequestDto
{
    // INFO : Profile Table //
    public string? UserPassword { get; set; }
    public string? ReplyPassword { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public DateTime CreationDate { get; set; }

    // INFO : User Table //
    [JsonIgnore]
    public short IdUser { get; set; }
    public string? PaternalLastName { get; set; }
    public string? MaternalLastName { get; set; }
    public string? CellPhone { get; set; }

    [JsonIgnore]
    public short IdUserProfile { get; set; }

    // INFO : Localidad Table //
    [JsonIgnore]
    public short IdLocation { get; set; }
    public string? Street { get; set; }
    public int HouseNumber { get; set; }
    public ProvinceEnum IdProvince { get; set; }
}
