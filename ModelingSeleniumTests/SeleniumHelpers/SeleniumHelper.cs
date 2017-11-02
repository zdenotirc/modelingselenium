using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ModelingSeleniumTests.SeleniumHelpers
{
    //Specflow:
    //[Binding]
    public static class SeleniumHelper
    {
        private static IWebDriver _driver;

        private static WebDriverWait _webDriverWait;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }

                _driver = new DriverFactory().Create();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

                return _driver;
            }
        }

        public static WebDriverWait WebDriverWait
        {
            get
            {
                if (_webDriverWait != null)
                {
                    return _webDriverWait;
                }

                _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

                return _webDriverWait;
            }
        }

        //Specflow:
        //[AfterTestRun]
        public static void AfterTestRun()
        {
            ResetDriver();
        }

        public static void ResetDriver()
        {
            try
            {
                if (_driver != null)
                {
                    Driver.Close();
                    Driver.Quit();
                    _driver = null;
                }
            }
            catch (Exception ex) { }
        }

        public static void Wait(this WebDriverWait webDriverWait, int miliseconds)
        {
            var delay = new TimeSpan(0, 0, 0, 0, miliseconds);
            var timestamp = DateTime.Now;

            webDriverWait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }
    }
}
