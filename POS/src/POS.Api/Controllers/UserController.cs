using Microsoft.AspNetCore.Mvc;
using POS.Application.DTO.Request;
using POS.Application.Interfaces;

namespace POS.src.POS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserEcoApplication _app;
        private readonly IUserProfileApplication _appProfile;

        public UserController(IUserEcoApplication app, IUserProfileApplication appProfile)
        {
            _app = app;
            _appProfile = appProfile;
        }

        /// <summary>
        /// List all users
        /// </summary>
        [HttpGet] // * GET: api/User/list //
        [Route("list")]
        public async Task<IActionResult> ListSelectUser()
        {
            var response = await _app.ListSelectUser();
            return Ok(response);
        }

        /// <summary>
        /// Search user by id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet] // * GET: api/User/{id} //
        [Route("list/{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await _app.GetUserById(id);
            return Ok(response);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///         POST api/User/Register
        ///         {
        ///             "userPassword": "Index123",
        ///             "replyPassword": "Index123",
        ///             "email": "camilo@gmail.com",
        ///             "name": "Camilo",
        ///             "paternalLastName": "Torres",
        ///             "maternalLastName": "Altaraz",
        ///             "cellPhone": "154728313",
        ///             "street": "Joser Ignacio",
        ///             "houseNumber": 1592,
        ///             "idProvince": 2
        ///         }
        ///
        ///</remarks>
        [HttpPost] // * POST: api/User/register
        [Route("Register/User")]
        [ProducesDefaultResponseType, Produces("application/json")]
        public async Task<IActionResult> RegisterUser([FromBody] UserEcoRequestDto user)
        {
            var response = await _appProfile.RegisterProfile(user);
            return Ok(response);
        }
    }
}
