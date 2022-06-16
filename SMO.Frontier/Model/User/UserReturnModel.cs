using SMO.Frontier.DTO.Address;
using SMO.Frontier.DTO.User;

namespace SMO.Frontier.Model.User
{
    public class UserReturnModel
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public string NumberPhone { get; set; }
        public IEnumerable<AddressDto> Address { get; set; }

        public UserReturnModel(UserDto userDto)
        {
            IdUser = userDto.IdUser;
            Name = userDto.Name;
            Email = userDto.Email;
            Password = userDto.Password;
            CPF = userDto.CPF;
            NumberPhone = userDto.NumberPhone;
            Address = userDto.AddressDtos;
        }
    }
}
