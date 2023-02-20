using POS.Application.Commons.Base;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;

namespace POS.Application.Services;

public class UserEcoApplication : IUserEcoApplication
{
    private readonly IUnitOfWork _unitOfWork;

    public UserEcoApplication(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<IEnumerable<UserEco>>> ListSelectUser()
    {
        var response = new BaseResponse<IEnumerable<UserEco>>();
        IEnumerable<UserEco> user = await _unitOfWork.UserEco.ListSelectUser();
        if (user is null)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMTY;
        }
        else
        {
            response.IsSuccess = true;
            response.Data = user;
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        return response;
    }
}
