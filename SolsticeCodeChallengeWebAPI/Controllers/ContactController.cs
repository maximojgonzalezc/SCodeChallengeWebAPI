using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolsticeCodeChallengeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeCodeChallengeWebAPI.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;
        public ContactController(ContactDbContext context)
        {
            _context = context;
            
            if (_context.Contacts.Count() == 0)
            {
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
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts([FromQuery(Name = "stateorcity")] string stateOrCity, [FromQuery(Name = "emailorphone")] string emailorphone)
        {
            if (!string.IsNullOrEmpty(stateOrCity) && !string.IsNullOrEmpty(emailorphone))
            {
                return new BadRequestObjectResult("Both query params must not have values");
            }

            if (!string.IsNullOrEmpty(stateOrCity))
            {
                var filteredList = await _context.Contacts.Where(e => 
                       e.Address.City.Equals(stateOrCity) || 
                        e.Address.State.Equals(stateOrCity))
                        .ToListAsync();
                if (filteredList.Count() == 0){return new NotFoundObjectResult($"There are no contacts with {stateOrCity} as their State nor City");}

                return new OkObjectResult(await _context.Contacts.Where(e => e.Address.City.Equals(stateOrCity) || e.Address.State.Equals(stateOrCity)).ToListAsync());
            }else if (!string.IsNullOrEmpty(emailorphone))
            {
                var contact = await _context.Contacts.Where(e =>
                    e.ContactPhone.PersonalPhone.Equals(emailorphone) ||
                    e.ContactPhone.WorkPhone.Equals(emailorphone) ||
                    e.Email.Equals(emailorphone)).
                    FirstOrDefaultAsync();
                if (contact == null){return new NotFoundObjectResult($"There is no contact with {emailorphone} as their Email nor their phone");}
                return new OkObjectResult(contact);
            }

            return new OkObjectResult(await _context.Contacts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            var contact = await _context.Contacts.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (contact == null)
            {
                return new NotFoundObjectResult($"There is no contact with ID: {id}");
            }
            return new OkObjectResult(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, Contact contact)
        {
            if (id != contact.Id)
            {
                return new BadRequestObjectResult($"There is no contact with ID: {id}");
            }

            _context.Update(contact).State = EntityState.Modified;
            // or the followings are also valid
            // context.Students.Update(contact);
            // context.Attach<Student>(contact).State = EntityState.Modified;
            // context.Entry<Student>(contact).State = EntityState.Modified; 

            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contact = await _context.Contacts.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (contact == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
