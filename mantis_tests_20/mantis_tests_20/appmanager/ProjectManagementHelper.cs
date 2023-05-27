using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_20
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projects = new List<ProjectData>();

            manager.Navigator.GoToManageProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//a[contains(@href,'manage_proj_edit_page.php')]"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }
            return projects;
        }

        public void Add(ProjectData project)
        {
            manager.Navigator.GoToManageProjectPage();
            InitProjectCreation();
            FillInProjectForm(project);
            SubmitProjectCreation();
        }


        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.btn")).Click();
            return this;
        }

        public ProjectManagementHelper FillInProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            Type(By.Name("name"), project.Name);
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        public void IsProjectPresent()
        {
            manager.Navigator.GoToManageProjectPage();
            if (IsElementPresent(By.XPath("//a[contains(@href,'manage_proj_edit_page.php')]")))
            {
                return;
            }
            else
            {
                Add(new ProjectData("yyyyy"));
            }
        }

        public ProjectManagementHelper Remove(int v)
        {
            manager.Navigator.GoToManageProjectPage();
            driver.FindElement(By.CssSelector("a[href*=\"manage_proj_edit_page.\"]")).Click();
            driver.FindElement(By.CssSelector("input.btn:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector("input.btn")).Click();
            return this;
        }
    }
}
