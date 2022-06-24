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
        Mock<IUserRepository> userRepository;
        Mock<IUserBusiness> userBusiness;

        public LoginBusinessTest()
        {
            userRepository = new Mock<IUserRepository>(MockBehavior.Strict);
            userBusiness = new Mock<IUserBusiness>(MockBehavior.Strict);

            loginBusiness = new LoginBusiness(
                userRepository.Object,
                userBusiness.Object
            );
        }

        private static readonly int ID_USER = 11;
        private static readonly int INVALID_ID_USER = 0;

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
        private static UserLogin InvalidUserLogin()
        {
            return new UserLogin
            {
                Email = "victor",
                Password = "12"
            };
        }
        #endregion

        [Fact]
        public async Task ShouldLoginUserCorrect()
        {
            userRepository.Setup(x => x.ValidateUser(
                It.IsAny<UserLogin>()
            )).ReturnsAsync(() => ID_USER);

            userBusiness.Setup(x => x.GetUserById(ID_USER)).ReturnsAsync(() => userDto);

            var userStructure = await loginBusiness.LoginUser(UserLogin());

            Assert.NotNull(userStructure);
            Assert.Equal("AP 102", userStructure.Complement);
        }

        [Fact]
        public async Task ShouldLoginUserIncorrect()
        {
            userRepository.Setup(x => x.ValidateUser(
                It.IsAny<UserLogin>()
            )).ReturnsAsync(() => INVALID_ID_USER);

            userBusiness.Setup(x => x.GetUserById(INVALID_ID_USER)).ReturnsAsync(() => new UserDto());

            var userStructure = await loginBusiness.LoginUser(InvalidUserLogin());

            Assert.Null(userStructure.Complement);
            Assert.Null(userStructure.Name);
        }
    }
}
