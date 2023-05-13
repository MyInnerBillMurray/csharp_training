using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("NewFirstName", "NewLastName");
            newData.OtherFields = "other";
            app.Contacts.ConfirmContactExists();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];
            app.Contacts.Modify(toBeModified, newData);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
