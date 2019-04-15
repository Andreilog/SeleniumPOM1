using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoWebApp.Tests
{
    public class ApplicationConfirmationPage
    {
        private readonly IWebDriver _driver;

        private IWebElement _firstName => _driver.FindElement(By.Id("firstName"));

        public ApplicationConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string FirstName => _firstName.Text;
    }
}
