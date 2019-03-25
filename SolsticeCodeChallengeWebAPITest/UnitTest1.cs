using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolsticeCodeChallengeWebAPI.Controllers;
using SolsticeCodeChallengeWebAPI.Models;
using SolsticeCodeChallengeWebAPI.Services;
using System.Collections.Generic;

namespace SolsticeCodeChallengeWebAPITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldThrowBadRequestActionResultWhenEmailIsAlreadyInUse()
        {
            var contact = new Contact()
            {
                Email = "testemail3@gmail.com"
            };

            List<Contact> contactList = new List<Contact>()
            {
                new Contact(){ Email = "testemail@gmail.com" },
                new Contact(){ Email = "testemail2@gmail.com" },
                new Contact(){ Email = "testemail3@gmail.com" }
            };

            var options = new DbContextOptionsBuilder<ContactDbContext>()
                      .UseInMemoryDatabase(databaseName: "ContactListDatabase")
                      .Options;

            var context = new ContactDbContext(options);

                context.Contacts.AddRange(contactList);
                context.SaveChanges();

                ContactService cs = new ContactService(context);

                ContactController cc = new ContactController(cs);

                var x = cc.PostContact(contact);

                Assert.IsInstanceOfType(x.Result.Result, typeof(Microsoft.AspNetCore.Mvc.BadRequestObjectResult));
        }

        [TestMethod]
        public void ShouldThrowCreatedAtActionResultWhenEmailIsNotInUse()
        {
            var contact = new Contact()
            {
                Email = "testemail4@gmail.com"
            };

            List<Contact> contactList = new List<Contact>()
            {
                new Contact(){ Email = "testemail@gmail.com" },
                new Contact(){ Email = "testemail2@gmail.com" },
                new Contact(){ Email = "testemail3@gmail.com" }
            };

            var options = new DbContextOptionsBuilder<ContactDbContext>()
                      .UseInMemoryDatabase(databaseName: "ContactListDatabase")
                      .Options;

            var context = new ContactDbContext(options);

            context.Contacts.AddRange(contactList);
            context.SaveChanges();

            ContactService cs = new ContactService(context);

            ContactController cc = new ContactController(cs);

            var x = cc.PostContact(contact);

            Assert.IsInstanceOfType(x.Result.Result, typeof(Microsoft.AspNetCore.Mvc.CreatedAtActionResult));
        }

    }
}
