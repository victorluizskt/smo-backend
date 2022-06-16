using SMO.Frontier.DTO.User;
using SMO.Frontier.Entities.User;
using SMO.Frontier.Model.UserLogin;

namespace SMO.Frontier.Repository.User
{
    public interface IUserRepository
    {
        Task<int> CreateUser(UserDto userDto);
        Task<bool> UpdateUser(UserDto userDto, int idUser);
        Task<UserEntity> GetUserById(int id);
        Task<bool> DeleteUserById(int id);
        Task<int> ValidateUser(UserLogin userLogin);
        Task<string> GetUserByCpf(string CpfUser);
    }
}
