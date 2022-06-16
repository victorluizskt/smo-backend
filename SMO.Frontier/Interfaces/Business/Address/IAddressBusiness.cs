using SMO.Frontier.DTO.Address;
using SMO.Frontier.Entities.Address;
using SMO.Frontier.Model;
using SMO.Frontier.Model.Address;

namespace SMO.Frontier.Interfaces.Business.Address
{
    public interface IAddressBusiness
    {
        Task<bool> CreateAddressUser(AddressCreateModel addressCreateModel, int idUser);
        Task<IEnumerable<AddressDto>> GetAddressById(int idUser);
        Task UpdateFlagAddress(int idUser);
        Task<bool> DeleteAddressUser(int idAddress);
        Task<bool> DeleteAllAddressUser(int idUser);
        Task<bool> UpdateAddress(AddressCreateModel addressModel, int idAddress);
    }
}
