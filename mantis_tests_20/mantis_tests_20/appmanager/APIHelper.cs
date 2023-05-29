using mantis_tests_20.Mantis;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.FedCm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_20
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {    
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Username, account.Password, issue);
        }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            List<ProjectData> projectsList = new List<ProjectData>();

            //List<Mantis.ProjectData> projects = new List<Mantis.ProjectData>();
            var projects = client.mc_projects_get_user_accessible(account.Username, account.Password);

            foreach (var project in projects)
            {
                projectsList.Add(new ProjectData()
                {
                    Id = project.id,
                    Name = project.name,
                    Description = project.description,
                });
            }
            return projectsList;
        }
        public void IsProjectPresent(AccountData account)
        {
            manager.Navigator.GoToManageProjectPage();
            if (IsElementPresent(By.XPath("//a[contains(@href,'manage_proj_edit_page.php')]")))
            {
                return;
            }
            else
            {
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = new ProjectData("test").Name;

                client.mc_project_add(account.Username, account.Password, project);
            }
        }
        public int GetProjectsCount(AccountData account)
        {
            return GetProjectsList(account).Count;
        }
    }
}
