using SMO.Frontier.DTO.User;
using SMO.Frontier.Interfaces.Business.Login;
using SMO.Frontier.Interfaces.Business.User;
using SMO.Frontier.Model.UserLogin;
using SMO.Frontier.Repository.User;

namespace SMO.Business.Login
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly IUserRepository UserRepository;
        private readonly IUserBusiness UsersBusiness;

        public LoginBusiness(IUserRepository userRepository, IUserBusiness userBusiness)
        {
            UserRepository = userRepository;
            UsersBusiness = userBusiness;
        }

        public async Task<UserDto> LoginUser(UserLogin userLogin)
        {
            var idUser = await UserRepository.ValidateUser(userLogin);
            return await UsersBusiness.GetUserById(idUser);
        }
    }
}
