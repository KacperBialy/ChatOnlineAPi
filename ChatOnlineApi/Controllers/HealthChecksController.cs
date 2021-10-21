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
    [Route("api/hc")]
    [EnableCors("MyAllowSpecificOrigins")]
    public class HealthChecksController : ControllerBase
    {
        /// <summary>
        /// Check Api condition
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> GetAsync()
        {
            return "Healthy";
        }
    }
}
