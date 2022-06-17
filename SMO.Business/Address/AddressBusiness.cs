using SMO.Frontier.DTO.Address;
using SMO.Frontier.Interfaces.Business.Address;
using SMO.Frontier.Model;
using SMO.Frontier.Model.Address;
using SMO.Frontier.Repository.Address;
using System.Transactions;

namespace SMO.Business.Address
{
    public class AddressBusiness : IAddressBusiness
    {
        private readonly IAddressRepository AddressRepository;
        public AddressBusiness(IAddressRepository addressRepository)
        {
            AddressRepository = addressRepository;
        }

        public async Task<bool> CreateAddressUser(AddressCreateModel addressCreateModel, int idUser)
        {
            var addressDto = new AddressDto(addressCreateModel);

            var addressUser = await GetAddressById(idUser);
            if (addressUser.Any())
            {
                await UpdateFlagAddress(idUser);
            }

            return await AddressRepository.CreateAddressUser(addressDto, idUser);
        }

        public async Task<IEnumerable<AddressDto>> GetAddressById(int idUser)
        {
            var addressUser = await AddressRepository.GetAddressById(idUser);
            return addressUser.Select(address => new AddressDto(address));
        }

        public async Task UpdateFlagAddress(int idUser)
        {
            await AddressRepository.UpdateFlagAddress(idUser);
        }

        public async Task<bool> DeleteAddressUser(int idAddress)
        {
            var latestId = await AddressRepository.GetLatestId(idAddress);
            var equals = CompareIds(latestId, idAddress);
            if (equals && latestId.Count() >= 2)
            {
                await AddressRepository.SetLatestFlagIdAddress(latestId.ElementAt(1));
            }

            return await AddressRepository.DeleteAddressUser(idAddress);
        }

        public async Task<bool> UpdateAddress(AddressCreateModel addressModel, int idAddress)
        {
           var addressDto = new AddressDto(addressModel);
           return await AddressRepository.UpdateAddress(addressDto, idAddress);
        }

        public async Task<bool> DeleteAllAddressUser(int idUser)
        {
            return await AddressRepository.DeleteAllAddressUser(idUser);
        }

        private bool CompareIds(IEnumerable<int> idsAdress, int idUserDelete)
        {
            var idAddress = idsAdress.FirstOrDefault();
            return idAddress.Equals(idUserDelete);
        }
    }
}
