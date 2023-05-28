using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_20
{
    [TestFixture]
    public class ProjectTests : AuthTestBase
    {
        public static IEnumerable<ProjectData> RandomProjectNameProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                //projects.Add(new ProjectData(GenerateRandomString(10)));
                projects.Add(new ProjectData("qweqwewqqeqw"));
            }
            return projects;
        }

        [Test, TestCaseSource("RandomProjectNameProvider")]
        public void ProjectCreation(ProjectData project, AccountData account)
        {
            List<ProjectData> oldProjects = app.API.GetProjectsList(account);

            app.Projects.Add(project);

            List<ProjectData> newProjects = app.API.GetProjectsList(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void ProjectRemoval(AccountData account)
        {
            app.API.CreateIfNotExist(account);

            List<ProjectData> oldProjects = app.API.GetProjectsList(account);

            app.Projects.Remove(0);

            List<ProjectData> newProjects = app.API.GetProjectsList(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
