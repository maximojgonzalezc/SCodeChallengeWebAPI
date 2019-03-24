using Microsoft.AspNetCore.Mvc;
using SolsticeCodeChallengeWebAPI.Models;
using SolsticeCodeChallengeWebAPI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeCodeChallengeWebAPI.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        //private readonly ContactDbContext _context;
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
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
                var filteredList = await _service.FilterAsync(stateOrCity);

                if (!(filteredList.Count() == 0))
                {
                    return new OkObjectResult(filteredList);
                }
                else return new NotFoundObjectResult($"There are no contacts with {stateOrCity} as their State nor City"); 

            }else if (!string.IsNullOrEmpty(emailorphone))
            {
                var contact = await _service.SearchAsync(emailorphone);

                if (contact != null)
                {
                    return new OkObjectResult(contact);
                }

                else return new NotFoundObjectResult($"There is no contact with {emailorphone} as their Email nor their phone"); 
            } 

            return new OkObjectResult(await _service.GetAllContactsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(long id)
        {
            var contact = await _service.GetContactByIdAsync(id);

            if (contact == null)
            {
                return new NotFoundObjectResult($"There is no contact with ID: {id}");
            }
            return new OkObjectResult(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            var existingContact = await _service.SearchAsync(contact.Email);

            if (existingContact == null)
            {
                await _service.SaveContactAsync(contact);
                return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
            }
            else return new BadRequestObjectResult($"The email {contact.Email} it´s already in use");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, Contact contact)
        {
            if (id != contact.Id)
            {
                return new BadRequestObjectResult($"There is no contact with ID: {id}");
            }

            await _service.UpdateContactAsync(contact);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contact = await _service.GetContactByIdAsync(id);

            if (contact == null)
            {
                return new NotFoundObjectResult($"There is no contact with ID: {id}");
            }

            await _service.DeleteContactAsync(contact);

            return new NoContentResult();
        }
    }
}
