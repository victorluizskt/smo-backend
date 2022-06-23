using SMO.Frontier.DTO.Address;
using SMO.Frontier.Entities.Address;

namespace SMO.Frontier.Repository.Address
{
    public interface IAddressRepository
    {
        Task<bool> CreateAddressUser(AddressDto addressDto, int idUser);
        Task<IEnumerable<AddressEntity>> GetAddressById(int idUser);
        Task UpdateFlagAddress(int idUser);
        Task<bool> DeleteAddressUser (int idAddress);
        Task<bool> UpdateAddress(AddressDto addressModel, int addressDto);
        Task<bool> DeleteAllAddressUser(int idUser);
        Task<IEnumerable<int>> GetAddressListOrderByDesc(int idUser);
        Task SetLatestFlagIdAddress(int idAddress);
    }
}
