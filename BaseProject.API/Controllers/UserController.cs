using BaseProject.Application.Features.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.API.Controllers
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }
    }
}