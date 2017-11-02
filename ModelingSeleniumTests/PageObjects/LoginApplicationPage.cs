using ModelingSeleniumTests.SeleniumHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ModelingSeleniumTests.PageObjects
{
    public class LoginApplicationPage
    {
        private readonly IWebDriver _driver;

        private IWebElement UserNameElement => _driver.FindElement(By.Id("lwUserName-inputEl"));

        private IWebElement PasswordElement => _driver.FindElement(By.Id("lwPassword-inputEl"));

        private IWebElement OpenButtonElement => _driver.FindElement(By.Id("button-1017-btnEl"));

        public LoginApplicationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public DashbordsPage LoginAs(string baseUrl, string username, string password)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            TypeUsername(username);
            TypePassword(password);

            return SubmitLogin();
        }

        private void TypeUsername(string userName)
        {
            UserNameElement.SendKeys(userName);
        }

        private void TypePassword(string password)
        {
            PasswordElement.SendKeys(password);
        }

        private DashbordsPage SubmitLogin()
        {
            SeleniumHelper.WebDriverWait.Until(d => OpenButtonElement.Displayed);
            OpenButtonElement.Click();

            return new DashbordsPage(_driver);
        }
    }
}

