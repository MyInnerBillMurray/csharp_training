using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]

    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("");
            app.Ftp.Upload("", null);
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData accountData = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain",
            };

            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void restoreConfig() 
        {
            app.Ftp.RestoreBackupFile("");
        }
    }
}
