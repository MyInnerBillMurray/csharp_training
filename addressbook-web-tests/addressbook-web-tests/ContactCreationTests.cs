using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using static System.Net.WebRequestMethods;
using System.Diagnostics.Contracts;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        private string baseURL;
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/addressbook";
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToContactsPage();
            ContactData contact = new ContactData("FirstName", "LastName");
            contact.OtherFields = "default";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
        }
        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        private void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys(contact.OtherFields);
            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.OtherFields);
        }

        private void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1550, 838);
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value=\'Login\']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
