using SMO.Frontier.DTO.Address;

namespace SMO.Frontier.Entities.Address
{
    public class AddressEntity
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
        public AddressEntity() { }

        public AddressEntity(AddressEntity addressEntity)
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

        public AddressEntity(AddressDto addressDto)
        {
            Street = addressDto.Street;
            City = addressDto.City;
            State = addressDto.State;
            PostalCode = addressDto.PostalCode;
            NumberHouse = addressDto.NumberHouse;
            Country = addressDto.Country;
            Complement = addressDto.Complement;
        }
    }
}