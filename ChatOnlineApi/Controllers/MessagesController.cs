using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatOnlineApi.Controllers
{
    [ApiController]
    [Route("api/{userId}/messages")]
    [EnableCors("MyAllowSpecificOrigins")]
    public class MessagesController : Controller
    {
        /// <summary>
        /// Retrieves all messages from the specified user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> GetAll()
        {
            return "Not implemented";
        }

        /// <summary>
        /// Sends a message to the specified user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Post()
        {
            return "Not implemented";
        }

        /// <summary>
        /// Modifies a message sent to the specified user
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> Put()
        {
            return "Not implemented";
        }

        /// <summary>
        /// Delete a message sent to the specified user
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{messageId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> Delete()
        {
            return "Not implemented";
        }
    }
}
