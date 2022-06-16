﻿namespace SMO.Frontier.Model.Address
{
    public class AddressCreateModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string NumberHouse { get; set; }
        public int Flag { get; set; }
        public string Country { get; set; } 
        public string Complement { get; set; }
    }
}