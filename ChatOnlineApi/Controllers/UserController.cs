using ChatOnline.Application.Users.GetUserDetail.Commands.DeleteUser;
using ChatOnline.Application.Users.GetUserDetail.Queries;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatOnlineApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    [EnableCors("MyAllowSpecificOrigins")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Register the user
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<string>> RegisterUser()
        {
            return "Not implemented";
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
        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailViewModel>> Deatils(int id)
        {
            var userDetailViewModel = await Mediator.Send(new GetUserDetailQuery() { UserId = id });

            return Ok(userDetailViewModel);
        }
    }
}
