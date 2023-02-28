using AutoMapper;
using FluentValidation;
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
    private readonly IValidator<UserEcoRequestDto> _validator;
    private readonly IMapper _mapper;

    public UserEcoApplication(
        IUnitOfWork unitOfWork,
        IValidator<UserEcoRequestDto> validator,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mapper = mapper;
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

    public async Task<BaseResponse<short>> RegisterUser(UserEcoRequestDto addUser)
    {
        var response = new BaseResponse<short>();
        UserEco newUser = _mapper.Map<UserEco>(addUser);
        UserEco user = await _unitOfWork.UserEco.CreateUserEco(newUser);
        if (user is not null)
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_SAVE;
            response.Data = user.IdUser;
        }
        return response;
    }
}
