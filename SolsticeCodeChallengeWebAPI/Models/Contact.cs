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
            [MaxLength(40)]
            public string Company { get; set; }
            public string ProfileImageURL { get; set; }
            [Required(ErrorMessage = "Contact Email is required ")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Birthday is required ")]
            public DateTime BirthDate { get; set; }
            [Required(ErrorMessage = "Contact phone is required ")]
            public ContactPhone ContactPhone { get; set; }
            [Required(ErrorMessage = "Contact Address is required ")]
            public Address Address { get; set; }
        }

        public class Address
        {
            public long Id { get; set; }
            [MaxLength(60)]
            [Required(ErrorMessage = "Address Line 1 is required ")]
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            [MaxLength(40)]
            [Required(ErrorMessage = "Address City is required ")]
            public string City { get; set; }
            [MaxLength(40)]
            [Required(ErrorMessage = "Address State is required ")]
            public string State { get; set; }
            public Contact Contact { get; set; }
        }

        public class ContactPhone
        {
            public long Id { get; set; }
            [Required(ErrorMessage = "Personal Phone is required ")]
            public string PersonalPhone { get; set; }
            public string WorkPhone { get; set; }
            public Contact Contact { get; set; }
        }
}

