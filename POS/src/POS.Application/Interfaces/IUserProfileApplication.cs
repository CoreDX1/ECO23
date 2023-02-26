using POS.Application.Commons.Base;
using POS.Application.DTO.Request;

namespace POS.Application.Interfaces;

public interface IUserProfileApplication
{
    Task<BaseResponse<bool>> RegisterUser(UserEcoRequestDto addUser);
}
