using POS.Application.Commons.Base;
using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IUserEcoApplication
{
    Task<BaseResponse<dynamic>> ListSelectUser();
}
