using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private string baseURL;
        public ContactHelper(ApplicationManager manager, string baseURL) : base(manager)
        { this.baseURL = baseURL; }
        
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            FillContactForm(contact);
            SubmitContactCreation(contact);
            ReturnToHomePage();
            return this;
        }
        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("//img[@alt=\'Edit\']")).Click();
            return this;
        }
        public ContactHelper Remove(int v)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            driver.FindElement(By.XPath("//input[@value=\'Delete\']")).Click();
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Delete 1 addresses?"));
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SubmitContactCreation(ContactData contact)
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.OtherFields);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.OtherFields);
            Type(By.Name("title"), contact.OtherFields);
            Type(By.Name("company"), contact.OtherFields);
            Type(By.Name("address"), contact.OtherFields);
            Type(By.Name("home"), contact.OtherFields);
            Type(By.Name("mobile"), contact.OtherFields);
            Type(By.Name("work"), contact.OtherFields);
            Type(By.Name("fax"), contact.OtherFields);
            Type(By.Name("email"), contact.OtherFields);
            Type(By.Name("email2"), contact.OtherFields);
            Type(By.Name("email3"), contact.OtherFields);
            Type(By.Name("homepage"), contact.OtherFields);
            Type(By.Name("address2"), contact.OtherFields);
            Type(By.Name("notes"), contact.OtherFields);
            Type(By.Name("phone2"), contact.OtherFields);
            return this;
        }

        public ContactHelper ClearContactForm()
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("phone2")).Clear();
            return this;
        }
        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            ClearContactForm();
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactHelper ConfirmContactExists()
        {
            if (! IsElementPresent(By.Name("selected[]")))
            {
                Create(new ContactData("FirstName", "LastName"));
            }
            return this;
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToContactsPage();
            ICollection<IWebElement> elements 
                = driver.FindElements(By.CssSelector("#maintable > tbody:nth-child(1) > [name=\"entry\"]"));

            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text, null));
            }
            return contacts;
        }
    }
}
