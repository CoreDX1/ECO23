using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces;

namespace POS.src.POS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserEcoApplication _app;

        public UserController(IUserEcoApplication app)
        {
            _app = app;
        }

        // * GET: api/User/list //
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListSelectUser()
        {
            var response = await _app.ListSelectUser();
            return Ok(response);
        }

        // * GET: api/User/{id} //
        [HttpGet]
        [Route("list/{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await _app.GetUserById(id);
            return Ok(response);
        }
    }
}
