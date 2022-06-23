using Microsoft.AspNetCore.Mvc;
using SMO.Frontier.Interfaces.Business.Login;
using SMO.Frontier.Model.User;
using SMO.Frontier.Model.UserLogin;
using System.Net;

namespace SMO.Backend.Controllers.v1.Login
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        public readonly ILoginBusiness LoginBusiness;
        public LoginController(ILoginBusiness loginBusiness)
        {
            LoginBusiness = loginBusiness;
        }

        /// <summary>
        /// Rota para logar o usuário
        /// </summary>
        /// <param name="userLogin">Utilizado para verificar se o usuário está cadastrado no sistema</param>
        /// <returns>Caso o usuário esteja cadastrado no sistema, será retornado seu usuário</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserReturnModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login(
            [FromBody] UserLogin userLogin  
        )
        {
           var user = await LoginBusiness.LoginUser(userLogin);
           if(user.Email is not null)
           {
               var userModel = new UserReturnModel(user);
               return Ok(userModel);
           }

            return BadRequest("Usuário não encontrado");
           
        }
    }
}
