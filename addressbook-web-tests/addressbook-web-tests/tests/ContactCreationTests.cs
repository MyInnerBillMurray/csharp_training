using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    OtherFields = GenerateRandomString(30)
                });
            }
            return contacts;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            app.Navigator.GoToHomePage();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.InitContactCreation();
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
