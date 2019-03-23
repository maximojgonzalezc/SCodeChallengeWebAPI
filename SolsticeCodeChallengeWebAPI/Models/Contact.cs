using System;
using System.ComponentModel.DataAnnotations;

namespace SolsticeCodeChallengeWebAPI.Models
{
    public class Contact
        {
            public long Id { get; set; }
            [MaxLength(40)]
            [Required(ErrorMessage = "Contact name is required ")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Company name is required ")]
            public string Company { get; set; }
            public string ProfileImageURL { get; set; }
            [Required(ErrorMessage = "Contact Emil is required ")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Birthday is required ")]
            public DateTime BirthDate { get; set; }
            [Required(ErrorMessage = "Contact phone is required ")]
            public ContactPhone ContactPhone { get; set; }
            public Address Address { get; set; }
        }

        public class Address
        {
            public long id { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public Contact Contact { get; set; }
            public long AddresssContactForeignKey { get; set; }
        }

        public class ContactPhone
        {
            public long ContactPhoneid { get; set; }
            public string PersonalPhone { get; set; }
            public string WorkPhone { get; set; }
            public Contact Contact { get; set; }
            public long ContactPhonesContactForeignKey { get; set; }
        }
}

