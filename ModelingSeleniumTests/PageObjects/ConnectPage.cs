using System;
using ModelingSeleniumTests.SeleniumHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ModelingSeleniumTests.PageObjects
{
    public class ConnectPage
    {
        private readonly IWebDriver _driver;

        private By ConnectSelector => By.Id("lwLoginToProject-btnEl");

        public IWebElement ConnectToAppElement => _driver.FindElement(ConnectSelector);

        public ConnectPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public DashbordsPage NavigateToDashboards()
        {
            SeleniumHelper.WebDriverWait.Until(d => ConnectToAppElement.Displayed);

            ConnectToAppElement.Click();
            return new DashbordsPage(_driver);
        }
    }
}