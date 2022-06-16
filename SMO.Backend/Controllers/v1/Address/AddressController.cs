using Microsoft.AspNetCore.Mvc;
using System.Net;
using SMO.Frontier.Interfaces.Business.Address;
using SMO.Frontier.Model;
using SMO.Frontier.Model.Address;

namespace SMO.Backend.Controllers.API.v1.Register
{
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBusiness AddressBusiness;

        public AddressController(IAddressBusiness addressBusiness)
        {
            AddressBusiness = addressBusiness;
        }

        /// <summary>
        /// Rota para criar um novo endereço para o usuário
        /// </summary>
        /// <param name="addressModel"></param>
        /// <returns></returns>
        [HttpPost("createAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAddressUser(
            [FromHeader] int idUser,
            [FromBody] AddressCreateModel addressModel   
        )
        {
            var success = await AddressBusiness.CreateAddressUser(addressModel, idUser);
            if (success)
            {
                return Ok(success);
            }

            return BadRequest();
        }

        /// <summary>
        /// Rota para atualizar o endereço do usuário, recebe como paramêtro via body um addressModel
        /// contendo todas as informações mais recentes que o usuário deseja atualizar
        /// </summary>
        /// <param name="addressModel"></param>
        /// <returns></returns>
        [HttpPut("updateAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAddressById(
            [FromHeader] int idAddress,
            [FromBody] AddressCreateModel addressModel
        )
        {
            var updated = await AddressBusiness.UpdateAddress(addressModel, idAddress);
            if (updated)
            {
                return Ok(updated);
            }

            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAddress(
            [FromHeader] int idAddress
        )
        {
            var deleted = await AddressBusiness.DeleteAddressUser(idAddress);
            if (deleted)
            {
                return Ok(deleted);
            }

            return BadRequest();
        }
    }
}
