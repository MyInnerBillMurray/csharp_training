using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace mantis_tests_20
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void OpenLoginPage()
        {
            if (driver.Url == "http://localhost/mantisbt-2.25.7//login_page.php")
            {
                return;
            }

            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.7//login_page.php");
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                   return;
                }
                Logout();
            }
            Type(By.Id("username"), "administrator");
            driver.FindElement(By.CssSelector(".width-40")).Click();
            Type(By.Id("password"), "root");
            driver.FindElement(By.CssSelector(".width-40")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;
        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
           {
                driver.FindElement(By.CssSelector(".user-info")).Click();
                driver.FindElement(By.CssSelector(".user-menu > li:nth-child(4) > a:nth-child(1)")).Click();
            }
        }
    }
}
