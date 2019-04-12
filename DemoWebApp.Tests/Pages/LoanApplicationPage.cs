using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoWebApp.Tests
{
    public class LoanApplicationPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"http://localhost:40077/Home/StartLoanApplication";

        private IWebElement _errorText => _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li"));

        private IWebElement _existingLoan => _driver.FindElement(By.Id("Loan"));

        private IWebElement _firstName => _driver.FindElement(By.Name("FirstName"));

        private IWebElement _secondName => _driver.FindElement(By.Name("LastName"));

        private IWebElement _submit => _driver.FindElement(By.CssSelector(".btn.btn-primary"));

        private IWebElement _termsAcceptance => _driver.FindElement(By.Name("TermsAcceptance"));


        public LoanApplicationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static LoanApplicationPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new LoanApplicationPage(driver);
        }

        public string FirstName
        {
            set
            {
                _firstName.SendKeys(value);
            }
        }

        public string SecondName
        {
            set
            {
                _secondName.SendKeys(value);
            }
        }

        public string ErrorText => _errorText.Text;

        public void SelectExistingLoan()
        {
            _existingLoan.Click();
        }

        public void AcceptTermsAndConditions()
        {
            _termsAcceptance.Click();
        }

        public ApplicationConfirmationPage SubmitApplication()
        {
            _submit.Click();

            return new ApplicationConfirmationPage(_driver);
        }
    }
}
