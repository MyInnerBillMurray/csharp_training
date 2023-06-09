﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL; 
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        { this.baseURL = baseURL; }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            { return; }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php" && IsElementPresent(By.Name("new")))
            { return; }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
