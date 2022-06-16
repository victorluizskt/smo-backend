using SMO.Frontier.DTO.Address;

namespace SMO.Frontier.Model
{
    public class AddressModel
    {
        public int IdAddress { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }  
        public string NumberHouse { get; set; }
        public int Flag { get; set; }
        public string Country { get; set; }
        public string Complement { get; set; }

        public AddressModel(AddressDto addressDto)
        {
            IdAddress = addressDto.IdAddress;
            Street = addressDto.Street;
            City = addressDto.City;
            State = addressDto.State;
            PostalCode = addressDto.PostalCode;
            NumberHouse = addressDto.NumberHouse;
            Flag = addressDto.Flag;
        }

        public AddressModel() { }
    }
}
