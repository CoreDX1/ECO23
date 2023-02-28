using AutoMapper;
using POS.Application.Commons.Base;
using POS.Application.DTO.Request;
using POS.Application.DTO.Response.Location;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;

namespace POS.Application.Services;

public class UserLocationApplication : IUserLocationApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserLocationApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<short>> RegisterLocation(UserEcoRequestDto addLocation)
    {
        var response = new BaseResponse<short>();
        var location = _mapper.Map<UserLocation>(addLocation);
        UserLocation data = await _unitOfWork.UserLocation.CreateUserLocation(location);
        if (data is not null)
        {
            response.IsSuccess = true;
            response.Data = data.IdLocation;
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        return response;
    }
}
