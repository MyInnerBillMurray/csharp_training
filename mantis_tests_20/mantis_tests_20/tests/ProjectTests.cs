using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_20
{
    [TestFixture]
    public class TestNewProjectCreation : AuthTestBase
    {
        public static IEnumerable<ProjectData> RandomProjectNameProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                projects.Add(new ProjectData(GenerateRandomString(10)));
            }
            return projects;
        }

        [Test, TestCaseSource("RandomProjectNameProvider")]
        public void ProjectCreation(ProjectData project)
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Add(project);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void ProjectRemoval()
        {
            app.Projects.IsProjectPresent();

            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Remove(0);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
