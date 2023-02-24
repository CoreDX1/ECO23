using POS.Application.Commons.Base;
using POS.Application.DTO.Request;
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

    public async Task<BaseResponse<UserEco>> GetUserById(int id)
    {
        var response = new BaseResponse<UserEco>();
        UserEco user = await _unitOfWork.UserEco.UserById(id);
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

    public async Task<BaseResponse<bool>> RegisterUser(UserComplete requestDto)
    {
        var response = new BaseResponse<bool>();
        response.Data = await _unitOfWork.UserEco.CreateUserEco(requestDto);
        await _unitOfWork.UserLocation.CreateUserLocation(requestDto);
        await _unitOfWork.UserProfile.CreateUserProfile(requestDto);
        if (!response.Data)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMTY;
        }
        else
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_SAVE;
        }
        return response;
    }
}
