using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using FluentValidation;
using POS.Application.Commons.Base;
using POS.Application.DTO.Request;
using POS.Application.DTO.Response;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;
using BC = BCrypt.Net.BCrypt;

namespace POS.Application.Services;

public class UserProfileApplication : IUserProfileApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserLocationApplication _Location;
    private readonly IUserEcoApplication _User;
    private readonly IMapper _mapper;
    private readonly IValidator<UserEcoRequestDto> _validator;

    public UserProfileApplication(
        IUnitOfWork unitOfWork,
        IUserLocationApplication location,
        IUserEcoApplication user,
        IMapper mapper,
        IValidator<UserEcoRequestDto> validator
    )
    {
        _unitOfWork = unitOfWork;
        _Location = location;
        _User = user;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<BaseResponse<bool>> RegisterProfile(UserEcoRequestDto addUser)
    {
        var response = new BaseResponse<bool>();
        var validate = await _validator.ValidateAsync(addUser);
        if (!validate.IsValid)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_VALIDATE;
            response.Errors = validate.Errors.Select(
                x => new ErrorsResponseDto { ErrorMessage = x.ErrorMessage }
            );
            return response;
        }

        // INFO : Creando el usuario
        var user = await _User.RegisterUser(addUser);

        // INFO : Creando el usuario => Location
        var location = await _Location.RegisterLocation(addUser);

        UserProfile data = _mapper.Map<UserProfile>(addUser);
        data.IdLocation = location.Data;
        data.IdUser = user.Data;

        data.UserPassword = BC.HashPassword(data.UserPassword);
        var profile = await _unitOfWork.UserProfile.Create(data);
        if (profile is null)
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
