using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace mantis_tests_20
{
    public class ManagementMenuHelper : HelperBase
    {
        public string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if (driver.Url == "http://localhost/mantisbt-2.25.7/account_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.7/account_page.php");
        }
        public void GoToManageProjectPage()
        {
            if (driver.Url == "http://localhost/mantisbt-2.25.7/manage_proj_page.php")
            {
                return;
            }
            driver.FindElement(By.CssSelector(".fa-gears")).Click();
            driver.FindElement(By.CssSelector(".nav-tabs > li:nth-child(3) > a:nth-child(1)")).Click();
        }
    }
}
