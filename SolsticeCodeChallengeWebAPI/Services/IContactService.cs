using SolsticeCodeChallengeWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolsticeCodeChallengeWebAPI.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactsAsync();

        Task<Contact> GetContactByIdAsync(long id);

        Task SaveContactAsync(Contact contact);

        Task DeleteContactAsync(Contact contact);

        Task UpdateContactAsync(Contact contact);

        Task<Contact> SearchAsync(string filterProp);

        Task<List<Contact>> FilterAsync(string filterProp);

        bool IsValidEmail(string email);
    }
}
