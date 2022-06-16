using SMO.Frontier.DTO.Address;
using SMO.Frontier.Entities.User;
using SMO.Frontier.Model.User;

namespace SMO.Frontier.DTO.User
{
    public class UserDto : AddressDto
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public string NumberPhone { get; set; }
        public IEnumerable<AddressDto> AddressDtos { get; set; }

        public UserDto(UserModel userModel)
        {
            IdUser = userModel.IdUser;
            Name = userModel.Name;
            Email = userModel.Email;
            Password = userModel.Password;
            CPF = userModel.CPF;
            NumberPhone = userModel.NumberPhone;
            Street = userModel.Street;
            City = userModel.City;
            State = userModel.State;
            PostalCode = userModel.PostalCode;
            NumberHouse = userModel.NumberHouse;
            Flag = userModel.Flag;
        }

        public UserDto(UserEntity userEntity)
        {
            IdUser = userEntity.IdUser;
            Name = userEntity.Name;
            Email = userEntity.Email;
            Password = userEntity.Password;
            CPF = userEntity.CPF;
            NumberPhone = userEntity.NumberPhone;
            AddressDtos = new List<AddressDto>();
        }

        public UserDto(UserUpdateModel userUpdateModel)
        {
            Name = userUpdateModel.Name;
            Email = userUpdateModel.Email;
            Password = userUpdateModel.Password;
            NumberPhone = userUpdateModel.NumberPhone;
        }

        public UserDto(UserCreateModel userCreateModel)
        {
            Name = userCreateModel.Name;
            CPF = userCreateModel.CPF;
            Email = userCreateModel.Email;
            Password = userCreateModel.Password;
            NumberPhone = userCreateModel.NumberPhone;
        }

        public UserDto() { }
    }
}
