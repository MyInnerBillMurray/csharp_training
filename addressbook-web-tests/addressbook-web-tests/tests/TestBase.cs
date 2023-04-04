using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using static System.Net.WebRequestMethods;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        [SetUp]
        public void SetUp()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        protected void TearDown()
        {
            app.Stop();
        }
    }
}
