using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace ModelingSeleniumTests.SeleniumHelpers
{
    public enum DriverToUse
    {
        InternetExplorer,
        Chrome
    }

    public class DriverFactory
    {
        public IWebDriver Create()
        {
            IWebDriver driver;
            var driverToUse = DriverToUse.Chrome;
            switch (driverToUse)
            {
                case DriverToUse.InternetExplorer:
                    driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory,
                        new InternetExplorerOptions(), TimeSpan.FromMinutes(5));
                    break;
                case DriverToUse.Chrome:
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // driver.Manage().Window.Maximize();
            ITimeouts timeouts = driver.Manage().Timeouts();
            timeouts.ImplicitWait = TimeSpan.FromSeconds(30);
            timeouts.PageLoad = TimeSpan.FromSeconds(60);

            // Suppress the onbeforeunload event first. This prevents the application hanging on a dialog box that does not close.
            ((IJavaScriptExecutor)driver).ExecuteScript("window.onbeforeunload = function(e){};");

            return driver;
        }
    }
}