using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("test1");
            group.Header = "me";
            group.Footer = "123";
            FillGroupsForm(group);
            SubmitGroupCreation();
            GoToGroupsPage();
        }
    }
}
