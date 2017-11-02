using ModelingSeleniumTests.SeleniumHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ModelingSeleniumTests.PageObjects
{
    public class DashbordsPage
    {
        private readonly IWebDriver _driver;

        public IWebElement DashboardsElement => _driver.FindElement(By.XPath("//span[contains(text(), 'Dashboards')]"));

        public IWebElement NavigationCloseElement => _driver.FindElement(By.XPath("//span[contains(text(), 'Close')]"));

        public IWebElement ModelingDashboardElement => _driver.FindElement(By.XPath("//span[contains(text(), 'Modeling Dashboard')]"));

        public DashbordsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ModelingPage DashboardsContentConnectionClick()
        {
            NavigationCloseClick();

            SeleniumHelper.WebDriverWait.Until(d => DashboardsElement.Displayed);
            DashboardsElement.Click();

            SeleniumHelper.WebDriverWait.Until(d => ModelingDashboardElement.Displayed);
            ModelingDashboardElement.Click();

            return new ModelingPage(_driver);
        }

        private void NavigationCloseClick()
        {
            SeleniumHelper.WebDriverWait.Until(d => NavigationCloseElement.Displayed);
            NavigationCloseElement.Click();
        }
    }
}
