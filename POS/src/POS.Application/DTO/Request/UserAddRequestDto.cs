namespace POS.Application.DTO.Request;

public class UserAddRequestDto
{
    public string? Name { get; set; }
    public string? PaternalLastName { get; set; }
    public string? MaternalLastName { get; set; }
    public string? CellPhone { get; set; }
}
