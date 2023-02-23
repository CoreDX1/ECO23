using POS.Application.Commons.Base;
using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IUserEcoApplication
{
    Task<BaseResponse<IEnumerable<UserEco>>> ListSelectUser();
    Task<BaseResponse<UserEco>> GetUserById(int id);
}
