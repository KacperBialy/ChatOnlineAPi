using ChatOnline.Application.Users.GetUserDetail.Commands.CreateUser;
using ChatOnline.Application.Users.GetUserDetail.Commands.DeleteUser;
using ChatOnline.Application.Users.GetUserDetail.Queries;
using ChatOnline.Application.Users.GetUserDetail.Queries.GetUserDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatOnlineApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    //[Authorize]
    public class UserController : BaseController
    {
        /// <summary>
        /// Create the user
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<string>> LogginUser()
        {
            return "Not implemented";
        }

        /// <summary>
        /// Delete a user by the specified id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await Mediator.Send(new DeleteUserCommand() { UserId = userId });
            return NoContent();
        }

        /// <summary>
        /// User details
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailsViewModel>> Deatils(int id)
        {
            var userDetailViewModel = await Mediator.Send(new GetUserDetailsQuery() { UserId = id });

            return Ok(userDetailViewModel);
        }
    }
}
