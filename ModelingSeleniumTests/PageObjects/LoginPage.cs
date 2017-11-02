using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ModelingSeleniumTests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public IWebElement UserNameElement => _driver.FindElement(By.Id("lwUserName-inputEl"));

        public IWebElement PasswordElement => _driver.FindElement(By.Id("lwPassword-inputEl"));

        public IWebElement SignInButtonElement => _driver.FindElement(By.Id("lwLoginToRepository-btnInnerEl"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public ConnectPage LoginAs(string baseUrl, string username, string password)
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

        private ConnectPage SubmitLogin()
        {
            SignInButtonElement.Click();

            return new ConnectPage(_driver);
        }
    }
}

