using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests_20
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected ManagementMenuHelper navigator;

        public ProjectManagementHelper Projects { get; set; }
        public APIHelper API { get; private set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost/mantisbt-2.25.7";
            loginHelper = new LoginHelper(this);
            navigator = new ManagementMenuHelper(this, baseURL);
            Projects = new ProjectManagementHelper(this);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {}
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
                newInstance.Auth.OpenLoginPage();
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }


        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ManagementMenuHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
    }
}
