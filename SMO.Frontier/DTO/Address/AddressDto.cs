using SMO.Frontier.Entities.Address;
using SMO.Frontier.Model;
using SMO.Frontier.Model.Address;

namespace SMO.Frontier.DTO.Address
{
    public class AddressDto
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

        public AddressDto(AddressEntity addressEntity)
        {
            IdAddress = addressEntity.IdAddress;
            Street = addressEntity.Street;
            City = addressEntity.City;
            State = addressEntity.State;
            PostalCode = addressEntity.PostalCode;
            NumberHouse = addressEntity.NumberHouse;
            Flag = addressEntity.Flag;
            Country = addressEntity.Country;
            Complement = addressEntity.Complement;
        }

        public AddressDto(AddressCreateModel addressCreateModel)
        {
            Street = addressCreateModel.Street;
            City = addressCreateModel.City;
            State = addressCreateModel.State;
            PostalCode = addressCreateModel.PostalCode;
            NumberHouse = addressCreateModel.NumberHouse;
            Complement = addressCreateModel.Complement;
            Country = addressCreateModel.Country;
        }

        public AddressDto(AddressModel addressModel)
        {
            Street = addressModel.Street;
            City = addressModel.City;
            State = addressModel.State;
            PostalCode = addressModel.PostalCode;
            NumberHouse = addressModel.NumberHouse;
            Flag = addressModel.Flag;
            Complement = addressModel.Complement;
            Country = addressModel.Country;
        }

        public AddressDto() { }
    }
}
