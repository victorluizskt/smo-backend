using SMO.Frontier.Model.Address;

namespace SMO.Frontier.Model.User
{
    public class UserModel : AddressModel
    {
        public int IdUser { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public string NumberPhone { get; set; }

        public UserModel() { }
    }

    public class UserCreateModel : AddressCreateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public string NumberPhone { get; set; }
    }
}
