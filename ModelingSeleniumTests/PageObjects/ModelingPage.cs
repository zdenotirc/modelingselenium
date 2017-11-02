using ModelingSeleniumTests.SeleniumHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ModelingSeleniumTests.PageObjects
{
    public class ModelingPage
    {
        private readonly IWebDriver _driver;

        public IWebElement CubesElement => _driver.FindElement(By.XPath("//span[contains(text(), 'Cubes')]"));

        public ModelingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void SelectCubesClick()
        {
            SeleniumHelper.WebDriverWait.Until(d => CubesElement.Displayed);
            CubesElement.Click();
        }
    }
}
