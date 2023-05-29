using NUnit.Framework;
using OpenQA.Selenium.DevTools.V113.FedCm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_20
{
    [TestFixture]
    public class ProjectTests : AuthTestBase
    {
        [Test]
        public void CreateProject()
        {
            AccountData account = new AccountData("administrator", "root");

            List<ProjectData> oldProjectsList = app.API.GetProjectsList(account);

            ProjectData project = new ProjectData(GenerateRandomString(5));

            app.Projects.Add(project);

            List<ProjectData> newProjectsList = app.API.GetProjectsList(account);

            //Assert.AreEqual(oldProjectsList.Count + 1, newProjectsList.Count);

            oldProjectsList.Add(project);
            oldProjectsList.Sort();
            newProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }

        [Test]
        public void RemoveProject()
        {
            AccountData account = new AccountData("administrator", "root");

            List<ProjectData> oldProjectsList = app.API.GetProjectsList(account);

            app.API.IsProjectPresent(account);

            app.Projects.Remove(0);

            List<ProjectData> newProjectsList = app.API.GetProjectsList(account);

            Assert.AreEqual(oldProjectsList.Count - 1, newProjectsList.Count);

            oldProjectsList.RemoveAt(0);
            oldProjectsList.Sort();
            newProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}
