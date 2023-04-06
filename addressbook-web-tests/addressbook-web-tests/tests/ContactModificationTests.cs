using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("NewFirstName", "NewLastName");
            newData.OtherFields = "other";

            app.Contacts.Modify(1, newData);
        }
    }
}
