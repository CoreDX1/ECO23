using FluentValidation;
using POS.Application.Commons.Base;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;
using BC = BCrypt.Net.BCrypt;

namespace POS.Application.Services;

public class UserEcoApplication : IUserEcoApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UserComplete> _validator;

    public UserEcoApplication(IUnitOfWork unitOfWork, IValidator<UserComplete> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
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
        var userV = await _validator.ValidateAsync(requestDto);
        if (!userV.IsValid)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_VALIDATE;
            response.Errors = userV.Errors;
            return response;
        }
        await _unitOfWork.UserEco.CreateUserEco(requestDto);
        await _unitOfWork.UserLocation.CreateUserLocation(requestDto);
        requestDto.UserPassword = BC.HashPassword(requestDto.UserPassword);
        response.Data = await _unitOfWork.UserProfile.CreateUserProfile(requestDto);
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
