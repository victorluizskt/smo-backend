using SMO.Frontier.DTO.Address;
using SMO.Frontier.Interfaces.Business.Address;
using SMO.Frontier.Model.Address;
using SMO.Frontier.Repository.Address;
using SMO.Utils;

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
            if(idUser <= 0)
            {
                return new List<AddressDto>();
            }

            var addressUser = await AddressRepository.GetAddressById(idUser);
            return addressUser.Select(address => new AddressDto(address));
        }

        public async Task UpdateFlagAddress(int idUser)
        {
            await AddressRepository.UpdateFlagAddress(idUser);
        }

        public async Task<bool> DeleteAddressUser(int idUser, int idAddress)
        {
            var addressListUser = await AddressRepository.GetAddressListOrderByDesc(idUser);
            var idsAddressEquals = CompareIds(addressListUser.FirstOrDefault(), idAddress);
            if (idsAddressEquals && addressListUser.Count() >= Constants.TWO_ADDRESS)
            {
                await AddressRepository.SetLatestFlagIdAddress(addressListUser.ElementAt(Constants.SECOND_ADRRESS));
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

        private bool CompareIds(int idAddress, int idUserDelete)
        {
            return idAddress.Equals(idUserDelete);
        }
    }
}
