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
                // which means you can't delete all Contacts.
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
        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var Contacts = await _context.Contacts.ToListAsync();
            return new OkObjectResult(Contacts);
        }
        // GET: api/Contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            var contact = await _context.Contacts.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (contact == null)
            {
                return NotFound();
            }
            return new OkObjectResult(contact);
        }
        // POST: api/Contact
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }
        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest("Wrong ID");
            }

            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/Todo/5
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
            return NoContent();
        }
    }
}
