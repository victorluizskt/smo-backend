using Moq;
using SMO.Business.Login;
using SMO.Frontier.DTO.User;
using SMO.Frontier.Interfaces.Business.Login;
using SMO.Frontier.Interfaces.Business.User;
using SMO.Frontier.Model.UserLogin;
using SMO.Frontier.Repository.User;
using System.Threading.Tasks;
using Xunit;

namespace SMO.Tests.Login
{
    public class LoginBusinessTest
    {
        private readonly ILoginBusiness loginBusiness;
        public LoginBusinessTest()
        {
            loginBusiness = new LoginBusiness(
                CreateMockedUserRepository(),
                CreateMockedUserBusiness()
            );
        }

        private static readonly int ID_USER = 11;

        #region Mock Return
        private UserDto userDto = new UserDto
        {
            Street = "Rua Stella Camargos",
            City = "Belo Horizonte",
            State = "Minas Gerais",
            PostalCode = "30520-300",
            NumberHouse = "341",
            Name = "Victor Luiz",
            Email = "victorluizcefet@gmail.com",
            Password = "1231456",
            CPF = "98745632100",
            NumberPhone = "319874563214",
            Country = "Brazil",
            Complement = "AP 102"
        };

        private static UserLogin UserLogin() {
            return new UserLogin
            {
                Email = "victorluizcefet@gmail.com",
                Password = "1231456"
            };
        }
        #endregion

        #region Mocks

        private IUserRepository CreateMockedUserRepository()
        {
            var userRepository = new Mock<IUserRepository>(MockBehavior.Strict);
            userRepository.Setup(x => x.ValidateUser(
                It.IsAny<UserLogin>()
            )).ReturnsAsync(() => ID_USER);

            return userRepository.Object;
        }

        private IUserBusiness CreateMockedUserBusiness()
        {
            var userBusiness = new Mock<IUserBusiness>(MockBehavior.Strict);
            userBusiness.Setup(x => x.GetUserById(ID_USER)).ReturnsAsync(() => userDto);

            return userBusiness.Object;
        }
        #endregion

        [Fact]
        public async Task ShouldLoginUserCorrect()
        {
            var userStructure = await loginBusiness.LoginUser(UserLogin());

            Assert.NotNull(userStructure);
            Assert.Equal("AP 102", userStructure.Complement);
        }
    }
}
