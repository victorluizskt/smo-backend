using SMO.Frontier.DTO.Address;
using SMO.Frontier.Model.User;
using SMO.Frontier.DTO.User;
using SMO.Frontier.Entities.User;
using SMO.Frontier.Interfaces.Business.Address;
using SMO.Frontier.Interfaces.Business.User;
using SMO.Frontier.Repository.User;
using System.Transactions;
using SMO.Frontier.Model;
using SMO.Frontier.Model.Address;

namespace SMO.Business.User
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository UserRepository;
        private readonly IAddressBusiness AddressBusiness;

        public UserBusiness(IUserRepository userRepository, IAddressBusiness addressBusiness)
        {
            UserRepository = userRepository;
            AddressBusiness = addressBusiness;
        }

        public async Task<bool> CreateUser(UserCreateModel userModel)
        {
            var userDto = new UserDto(userModel);

            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var cpfExists = await UserRepository.GetUserByCpf(userModel.CPF);
            if (cpfExists is not null)
                return false;
            var idUser = await UserRepository.CreateUser(userDto);
            var addressModel = CreateAddresModel(userModel);
            await AddressBusiness.CreateAddressUser(addressModel, idUser);
            transactionScope.Complete();
            return true;
        }

        public async Task<bool> UpdateUser(UserUpdateModel userModel, int idUser)
        {
            var userDto = new UserDto(userModel);

            return await UserRepository.UpdateUser(userDto, idUser);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var userEntity = await UserRepository.GetUserById(id);
            var addressUser = await AddressBusiness.GetAddressById(id);
            transactionScope.Complete();

            var mergeUserAddress = MergeUserAddress(userEntity, addressUser);

            if (mergeUserAddress is not null)
            {
                return mergeUserAddress;
            }

            return new UserDto();
        }

        public async Task<bool> DeleteUserById(int idUser)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var deleteAddress = await AddressBusiness.DeleteAllAddressUser(idUser);
            var deleteUser = await UserRepository.DeleteUserById(idUser);
            transactionScope.Complete();
            return deleteAddress && deleteUser;
        }

        #region Private
        private static UserDto MergeUserAddress(UserEntity? userEntity, IEnumerable<AddressDto> addressUser)
        {
            if(userEntity is not null)
            {
                var userDto = new UserDto(userEntity);
                if (addressUser.Any())
                {
                    userDto.AddressDtos = addressUser;
                }

                return userDto;
            }

            return new UserDto();
        }

        private static AddressCreateModel CreateAddresModel(UserCreateModel userModel)
        {
            return new AddressCreateModel()
            { 
                City = userModel.City,
                NumberHouse = userModel.NumberHouse,
                PostalCode = userModel.PostalCode,
                State = userModel.State,
                Street = userModel.Street,
                Country = userModel.Country,
                Complement = userModel.Complement
            };
        }
        #endregion

    }
}
