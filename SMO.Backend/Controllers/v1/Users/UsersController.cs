using Microsoft.AspNetCore.Mvc;
using System.Net;
using SMO.Utils.Validations;
using SMO.Frontier.Interfaces.Business.User;
using SMO.Frontier.Model.User;

namespace SMO.Backend.Controllers.v1.Users
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness UserBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            UserBusiness = userBusiness;
        }

        #region Routes
        /// <summary>
        /// Rota para cadastrar o usuário no sistema
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns>Caso o usuário seja criado com sucesso será retornado 200 OK</returns>
        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUser(
            [FromBody] UserCreateModel userModel
        )
        {
            if (!ValidationUser.ValidateUser(userModel))
                return BadRequest("Invalid parameters.");

            var success = await UserBusiness.CreateUser(userModel);
            if (success)
                return Ok(success);
            else
                return BadRequest("Usuário já existe em nossa base de dados.");
        }

        /// <summary>
        /// Rota feita para alterar as informações do usuário
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns>Caso seja retornado true, o usuário foi alterado com sucesso.</returns>
        [HttpPut("updateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUserById(
            [FromHeader] int idUser,
            [FromBody] UserUpdateModel userModel
        )
        {
            var success = await UserBusiness.UpdateUser(userModel, idUser);
            if (success)
            {
                return Ok(success);
            }

            return BadRequest(success); 
        }

        /// <summary>
        /// Rota para deletar um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um true caso for deletado com sucesso.</returns>
        [HttpDelete("deleteUser")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUser(
            [FromHeader] int idUser
        )
        {
            var deleted = await UserBusiness.DeleteUserById(idUser);
            if (deleted)
            {
                return Ok(deleted);
            }

            return BadRequest(deleted);
        }

        #endregion
    }
}
