using Moq;
using SMO.Business.User;
using SMO.Frontier.DTO.Address;
using SMO.Frontier.DTO.User;
using SMO.Frontier.Entities.User;
using SMO.Frontier.Interfaces.Business.Address;
using SMO.Frontier.Interfaces.Business.User;
using SMO.Frontier.Model.Address;
using SMO.Frontier.Model.User;
using SMO.Frontier.Repository.User;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SMO.Tests.User
{
    public class UserTest
    {
        private readonly IUserBusiness UserBusiness;
        Mock<IAddressBusiness> addressBusiness;
        Mock<IUserRepository> userRepository;

        public UserTest()
        {
            userRepository = new Mock<IUserRepository>(MockBehavior.Strict);
            addressBusiness = new Mock<IAddressBusiness>(MockBehavior.Strict);

            UserBusiness = new UserBusiness(userRepository.Object, addressBusiness.Object);
        }

        #region Mock Return
        private readonly int VALID_ID_USER = 23;
        private readonly string INVALID_CPF = string.Empty;
        private readonly string VALID_CPF = "123";

        private UserCreateModel userCreateModel()
        {
            return new UserCreateModel()
            {
                Street = "Avenida Ana Moura",
                City = "Timóteo",
                State = "MG",
                PostalCode = "35183000",
                NumberHouse = "1861",
                Country = "Brazil",
                Complement = "AP 102",
                Name = "Victor Luiz",
                Email = "victorluiz@gmail.com",
                Password = "123",
                CPF = "123",
                NumberPhone = "3198451551515"
            };
        }

        private UserEntity userCreateEntity()
        {
            return new UserEntity()
            {
                Street = "Avenida Ana Moura",
                City = "Timóteo",
                State = "MG",
                PostalCode = "35183000",
                NumberHouse = "1861",
                Country = "Brazil",
                Complement = "AP 102",
                Name = "Victor Luiz",
                Email = "victorluiz@gmail.com",
                Password = "123",
                CPF = "123",
                NumberPhone = "3198451551515"
            };
        }

        private UserEntity userCreateEntityNull()
        {
            return new UserEntity() { };
        }

        private IEnumerable<AddressDto> addressDto()
        {
            return new List<AddressDto>
            {
                new AddressDto()
                {
                    City = "Timóteo",
                    Complement = "AP 1111",
                    Country = "Brazil",
                    NumberHouse = "101",
                    PostalCode = "3511110",
                    State = "SP",
                    Street = "Rua Olivia"
                }
            };
        }

        private UserUpdateModel userUpdateModel()
        {
            return new UserUpdateModel()
            {
                Name = "Victor Luiz",
                Email = "victorluiz@gmail.com",
                Password = "123",
                NumberPhone = "3198451551515"
            };
        }
        #endregion

        #region Facts
        [Fact]
        public async Task ShouldCreateUserSuccess()
        {
            userRepository.Setup(x => x.GetUserByCpf(It.IsAny<string>())).ReturnsAsync(() => INVALID_CPF);
            userRepository.Setup(x => x.CreateUser(It.IsAny<UserDto>())).ReturnsAsync(() => VALID_ID_USER);
            addressBusiness.Setup(x => x.CreateAddressUser(It.IsAny<AddressCreateModel>(), It.IsAny<int>())).ReturnsAsync(() => true);

            var successCreateUser = await UserBusiness.CreateUser(userCreateModel());
            Assert.True(successCreateUser);
        }

        [Fact]
        public async Task ShouldCreateUserFailedCpfExists()
        {
            userRepository.Setup(x => x.GetUserByCpf(It.IsAny<string>())).ReturnsAsync(() => VALID_CPF);
            userRepository.Setup(x => x.CreateUser(It.IsAny<UserDto>())).ReturnsAsync(() => VALID_ID_USER);
            addressBusiness.Setup(x => x.CreateAddressUser(It.IsAny<AddressCreateModel>(), It.IsAny<int>())).ReturnsAsync(() => true);

            var failedCreateUser = await UserBusiness.CreateUser(userCreateModel());
            Assert.False(failedCreateUser);
        }

        [Fact]
        public async Task ShouldUpdateUserSuccess()
        {
            userRepository.Setup(x => x.UpdateUser(It.IsAny<UserDto>(), It.IsAny<int>())).ReturnsAsync(() => true);

            var successCreateUser = await UserBusiness.UpdateUser(userUpdateModel(), VALID_ID_USER);
            Assert.True(successCreateUser);
        }

        [Fact]
        public async Task ShouldGetUserById()
        {
            userRepository.Setup(x => x.GetUserById(It.IsAny<int>())).ReturnsAsync(() => userCreateEntity());
            addressBusiness.Setup(x => x.GetAddressById(It.IsAny<int>())).ReturnsAsync(() => addressDto());

            var userDto = await UserBusiness.GetUserById(VALID_ID_USER);
            Assert.NotNull(userDto);
            Assert.StrictEqual(1, userDto.AddressDtos.Count());
            Assert.Equal("Brazil", userDto.AddressDtos.First().Country);
            Assert.Equal("123", userDto.CPF);
        }


        [Fact]
        public async Task ShouldGetUserByIdFailed()
        {
            userRepository.Setup(x => x.GetUserById(It.IsAny<int>())).ReturnsAsync(() => userCreateEntityNull());
            addressBusiness.Setup(x => x.GetAddressById(It.IsAny<int>())).ReturnsAsync(() => addressDto());

            var userDto = await UserBusiness.GetUserById(VALID_ID_USER);
            Assert.Null(userDto.CPF);
        }

        [Fact]
        public async Task ShouldDeleteUserByIdCorrect()
        {
            addressBusiness.Setup(x => x.DeleteAllAddressUser(It.IsAny<int>())).ReturnsAsync(() => true);
            userRepository.Setup(x => x.DeleteUserById(It.IsAny<int>())).ReturnsAsync(() => true);

            var userDto = await UserBusiness.DeleteUserById(VALID_ID_USER);
            Assert.True(userDto);
        }

        [Fact]
        public async Task ShouldDeleteUserByIdInCorrect()
        {
            addressBusiness.Setup(x => x.DeleteAllAddressUser(It.IsAny<int>())).ReturnsAsync(() => true);
            userRepository.Setup(x => x.DeleteUserById(It.IsAny<int>())).ReturnsAsync(() => false);

            var userDto = await UserBusiness.DeleteUserById(VALID_ID_USER);
            Assert.False(userDto);
        }
        #endregion
    }
}
