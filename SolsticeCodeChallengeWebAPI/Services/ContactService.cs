using Microsoft.EntityFrameworkCore;
using SolsticeCodeChallengeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeCodeChallengeWebAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactDbContext _context;

        public ContactService(ContactDbContext context)
        {
            _context = context;

            // Create a new Contact if collection is empty,
            
                _context.Contacts.Add(new Contact
                {
                    Name = "Proof1",
                    Company = "Organization X",
                    ProfileImageURL = "SomeURL",
                    Email = "example@live.com",
                    BirthDate = new DateTime(1991, 02, 28),
                    ContactPhone = new ContactPhone
                    {
                        PersonalPhone = "123456",
                        WorkPhone = "456789"
                    },
                    Address = new Address
                    {
                        AddressLine1 = "4321 Sesame Street",
                        AddressLine2 = "Suite 900",
                        City = "Hollywood",
                        State = "Los Angeles"
                    }
                });
                _context.SaveChanges();
            
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();

            return contacts;
        }

        public async Task<Contact> GetContactByIdAsync(long id)
        {
            return await _context.Contacts.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _context.Update(contact).State = EntityState.Modified;
            // or the followings are also valid
            // context.Students.Update(contact);
            // context.Attach<Student>(contact).State = EntityState.Modified;
            // context.Entry<Student>(contact).State = EntityState.Modified; 

            await _context.SaveChangesAsync();
        }

        public async Task<Contact> SearchAsync(string filterProp)
        {
            var contact = await _context.Contacts.Where(e =>
                e.ContactPhone.PersonalPhone.Equals(filterProp) ||
                e.ContactPhone.WorkPhone.Equals(filterProp) ||
                e.Email.Equals(filterProp)).
                FirstOrDefaultAsync();

            return contact;
        }

        public async Task<List<Contact>> FilterAsync(string filterProp)
        {
            var filteredList = await _context.Contacts.Where(e =>
                   e.Address.City.Equals(filterProp) ||
                    e.Address.State.Equals(filterProp))
                    .ToListAsync();

            return filteredList;
        }
    }
}
