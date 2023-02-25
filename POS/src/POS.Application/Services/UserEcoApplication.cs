using AutoMapper;
using FluentValidation;
using POS.Application.Commons.Base;
using POS.Application.DTO.Request;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;
using BC = BCrypt.Net.BCrypt;

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

    public async Task<BaseResponse<bool>> RegisterUser(UserEcoRequestDto addUser)
    {
        var response = new BaseResponse<bool>();
        var userV = await _validator.ValidateAsync(addUser);
        if (!userV.IsValid)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_VALIDATE;
            response.Errors = userV.Errors;
            return response;
        }
        // INFO : Crea el Usuario
        UserEco newUser = _mapper.Map<UserEco>(addUser);
        var useriD = await _unitOfWork.UserEco.CreateUserEco(newUser);

        // INFO : Crea el Localidad
        UserLocation newLocation = _mapper.Map<UserLocation>(addUser);
        var locationiD = await _unitOfWork.UserLocation.CreateUserLocation(newLocation);

        // INFO : Crea el Profile
        UserProfile newProfile = _mapper.Map<UserProfile>(addUser);

        // INFO : Les asigna el Id
        newProfile.IdUser = useriD;
        newProfile.IdLocation = locationiD;

        // INFO : Se Hash la contraseña
        newProfile.UserPassword = BC.HashPassword(newProfile.UserPassword);

        // INFO : Se crea el Guarda
        response.Data = await _unitOfWork.UserProfile.CreateUserProfile(newProfile);
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
