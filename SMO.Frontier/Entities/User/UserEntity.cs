using SMO.Frontier.DTO.User;
using SMO.Frontier.Entities.Address;
using SMO.Frontier.Model.User;

namespace SMO.Frontier.Entities.User
{
    public class UserEntity : AddressEntity
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public string NumberPhone { get; set; }
        public UserEntity() { }

        public UserEntity(UserModel userModel) 
        {
            IdUser = userModel.IdUser;
            Name = userModel.Name;
            Email = userModel.Email;
            Password = userModel.Password;
            CPF = userModel.CPF;
            NumberPhone = userModel.NumberPhone;
        }

        public UserEntity(UserDto userDto)
        {
            IdUser = userDto.IdUser;
            Name = userDto.Name;
            Email = userDto.Email;
            Password = userDto.Password;
            CPF = userDto.CPF;
            NumberPhone = userDto.NumberPhone;
        }
    }
}
