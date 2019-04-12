using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DemoWebApp.Tests
{
    public class LoanApplicationTests
    {
        [Fact]
        public void StartApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://localhost:40077/");

                IWebElement applicationButton = driver.FindElement(By.Id("startApplication"));

                applicationButton.Click();

                Assert.Equal("Start Loan Application - Loan Application", driver.Title);
            }
        }

        [Fact]
        public void SubmitApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                /*
                driver.Navigate().GoToUrl("http://localhost:40077/Home/StartLoanApplication");

                IWebElement firstNameInput = driver.FindElement(By.Id("FirstName"));
                firstNameInput.SendKeys("Sarah");

                driver.FindElement(By.Id("LastName")).SendKeys("Smith");


                driver.FindElement(By.Id("Loan")).Click();


                driver.FindElement(By.Name("TermsAcceptance")).Click();


                driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();


                IWebElement confirmationNameSpan = driver.FindElement(By.Id("firstName"));
                */

                var page = LoanApplicationPage.NavigateTo(driver);
                page.FirstName = "Sarah";
                page.SecondName = "Smith";
                page.SelectExistingLoan();
                page.AcceptTermsAndConditions();
                var confPage = page.SubmitApplication();
                //confPage.FirstName = "Sarah";

                //string confirmationName = confirmationNameSpan.Text;
                var confirmationName = confPage.FirstName;

                Assert.Equal("Sarah", confirmationName);
            }
        }

    }
}
