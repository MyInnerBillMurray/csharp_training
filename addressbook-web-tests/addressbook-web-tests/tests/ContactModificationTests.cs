using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("NewFirstName", "NewLastName");
            newData.OtherFields = "other";
            app.Contacts.ConfirmContactExists();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(0, newData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
