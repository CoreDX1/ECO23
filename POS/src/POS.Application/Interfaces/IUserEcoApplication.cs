using POS.Application.Commons.Base;
using POS.Application.DTO.Request;
using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IUserEcoApplication
{
    Task<BaseResponse<IEnumerable<UserEco>>> ListSelectUser();
    Task<BaseResponse<UserEco>> GetUserById(short id);
    Task<BaseResponse<short>> RegisterUser(UserEcoRequestDto addUser);
}
