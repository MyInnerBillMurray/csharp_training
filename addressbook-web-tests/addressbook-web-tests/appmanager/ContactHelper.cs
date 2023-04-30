using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation(contact);
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            SelectContact();
            RemoveContact();
            contactCache = null;
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Delete 1 addresses?"));
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value=\'Delete\']")).Click();
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a"))
                .Click();
            return this;
        }
        public ContactHelper OpenContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a"))
                .Click();
            return this;
        }
        public ContactHelper SubmitContactCreation(ContactData contact)
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
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
            InitContactModification(v);
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
            contactCache = null;
            return this;
        }
        public ContactHelper ConfirmContactExists()
        {
            manager.Navigator.GoToHomePage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                Create(new ContactData("FirstName", "LastName"));
            }
            return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone1 = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");         

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                HomePhone1 = homePhone1,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Address2 = address2,
                HomePhone2 = homePhone2,
                Notes = notes
            };
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public string GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactDetails(0);
            string content = driver.FindElement(By.Id("content")).Text;
            return content;
        }
    }
}
