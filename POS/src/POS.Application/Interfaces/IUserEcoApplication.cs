using POS.Application.Commons.Base;
using POS.Application.DTO.Request;
using POS.Domain.Entities;
using POS.Utilities.Static;

namespace POS.Application.Interfaces;

public interface IUserEcoApplication
{
    Task<BaseResponse<IEnumerable<UserEco>>> ListSelectUser();
    Task<BaseResponse<UserEco>> GetUserById(int id);
    Task<BaseResponse<bool>> RegisterUser(UserComplete requestDto);
}
