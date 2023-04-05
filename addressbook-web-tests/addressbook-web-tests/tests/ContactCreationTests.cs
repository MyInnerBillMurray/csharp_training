using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToContactsPage();
            ContactData contact = new ContactData("FirstName", "LastName");
            contact.OtherFields = "default";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation(contact);
            app.Navigator.ReturnToHomePage();
        }
    }
}
