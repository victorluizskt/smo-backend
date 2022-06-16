using SMO.Frontier.DTO.User;
using SMO.Frontier.Model.User;

namespace SMO.Frontier.Interfaces.Business.User
{
    public interface IUserBusiness
    {
        Task<bool> CreateUser(UserCreateModel userModel);
        Task<bool> UpdateUser(UserUpdateModel userModel, int idUser);
        Task<UserDto> GetUserById(int id);
        Task<bool> DeleteUserById(int id);
    }
}
