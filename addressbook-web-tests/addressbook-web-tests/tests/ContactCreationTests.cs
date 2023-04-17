using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToContactsPage();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contact = new ContactData("FirstName", "LastName");
            contact.OtherFields = "default";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation(contact);
            app.Navigator.ReturnToHomePage();
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
