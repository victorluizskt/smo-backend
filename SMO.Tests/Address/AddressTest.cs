using Moq;
using SMO.Business.Address;
using SMO.Frontier.DTO.Address;
using SMO.Frontier.Entities.Address;
using SMO.Frontier.Interfaces.Business.Address;
using SMO.Frontier.Model.Address;
using SMO.Frontier.Repository.Address;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SMO.Tests.Address
{
    public class AddressTest
    {
        private readonly IAddressBusiness AddressBusiness;
        Mock<IAddressRepository> addressRepository;

        public AddressTest()
        {
            addressRepository = new Mock<IAddressRepository>(MockBehavior.Loose);

            AddressBusiness = new AddressBusiness(
                addressRepository.Object
            );
        }

        #region Mock Return
        private readonly int VALID_ID_USER = 23;
        private readonly int INVALID_ID_USER = 0;
        private readonly int VALID_ID_ADDRESS_USER = 55;

        private AddressCreateModel AddressCreateModel()
        {
            return new AddressCreateModel
            {
                City = "Timóteo",
                Complement = "AP 1111",
                Country = "Brazil",
                NumberHouse = "101",
                PostalCode = "3511110",
                State = "SP",
                Street = "Rua Olivia"
            };
        }

        private IEnumerable<AddressEntity> ListAddressDto()
        {
            return new List<AddressEntity> {
                new AddressEntity
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
        #endregion

        #region Facts
        private IEnumerable<int> ListIdAddressUser()
        {
            return new List<int>()
            {
                55, 41, 30, 21
            };
        }

        [Fact]
        public async Task ShouldDeleteUserSuccess()
        {
            addressRepository.Setup(x => x.DeleteAllAddressUser(VALID_ID_USER)).ReturnsAsync(() => true);
            var success = await AddressBusiness.DeleteAllAddressUser(VALID_ID_USER);

            Assert.True(success);
        }

        [Fact]
        public async Task ShouldCreateAddressUserCorrect()
        {
            addressRepository.Setup(x => x.GetAddressById(VALID_ID_USER)).ReturnsAsync(() => ListAddressDto());
            addressRepository.Setup(x => x.CreateAddressUser(It.IsAny<AddressDto>(), VALID_ID_USER)).ReturnsAsync(() => true);

            var updateSuccess = await AddressBusiness.CreateAddressUser(AddressCreateModel(), VALID_ID_USER);

            Assert.True(updateSuccess);
        }

        [Fact]
        public async Task ShouldGetAddressByIdCorrect()
        {
            addressRepository.Setup(x => x.GetAddressById(VALID_ID_USER)).ReturnsAsync(() => ListAddressDto());

            var addressUser = await AddressBusiness.GetAddressById(VALID_ID_USER);

            Assert.NotNull(addressUser);
            Assert.Equal("Timóteo", addressUser.First().City);
        }

        [Fact]
        public async Task ShouldGetAddressByIdIncorrect()
        {
            addressRepository.Setup(x => x.GetAddressById(INVALID_ID_USER)).ReturnsAsync(() => new List<AddressEntity>());

            var addressUser = await AddressBusiness.GetAddressById(INVALID_ID_USER);
            Assert.True(addressUser.Count() == 0);
        }

        [Fact]
        public async Task ShouldUpdateAddressUserCorrect()
        {
            addressRepository.Setup(x => x.UpdateAddress(It.IsAny<AddressDto>(), VALID_ID_USER)).ReturnsAsync(() => true) ;

            var success = await AddressBusiness.UpdateAddress(AddressCreateModel(), VALID_ID_USER);
            Assert.True(success);
        }

        [Fact]
        public async Task ShouldDeleteAddressUser()
        {
            addressRepository.Setup(x => x.GetAddressListOrderByDesc(It.IsAny<int>())).ReturnsAsync(() => ListIdAddressUser());
            addressRepository.Setup(x => x.DeleteAddressUser(It.IsAny<int>())).ReturnsAsync(() => true);

            var success = await AddressBusiness.DeleteAddressUser(VALID_ID_USER, VALID_ID_ADDRESS_USER);
            Assert.True(success);
        }
        #endregion
    }
}
