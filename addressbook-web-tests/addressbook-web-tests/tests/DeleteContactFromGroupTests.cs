using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{

    [TestFixture]

    public class DeleteContactFromGroupTests : AuthTestBase
    {

        [Test]
        public void TestDeleteContactFromGroup()
        {
            app.Groups.ConfirmGroupExists();
            app.Contacts.ConfirmContactExists();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll()[0];

            app.Contacts.ConfirmContactInGroupExists(contact, group);
            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
