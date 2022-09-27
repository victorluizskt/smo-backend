using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MC.Backend.Controllers.v1.Login
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login()
        {
            return Ok(200);
        }
    }
}
