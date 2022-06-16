using SMO.Frontier.DTO.User;
using SMO.Frontier.Model.UserLogin;

namespace SMO.Frontier.Interfaces.Business.Login
{
    public interface ILoginBusiness
    {
        Task<UserDto> LoginUser(UserLogin userLogin);
    }
}
