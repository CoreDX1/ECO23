using POS.Application.Commons.Base;
using POS.Application.DTO.Request;

namespace POS.Application.Interfaces;

public interface IUserLocationApplication
{
    Task<BaseResponse<short>> RegisterLocation(UserEcoRequestDto addLocation);
}
