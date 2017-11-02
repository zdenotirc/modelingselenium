using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace ModelingSeleniumTests.SeleniumHelpers
{
    public static class WebDriverExtensions
    {
        private static IEnumerable<object> FindElements(IWebDriver driver, string selector)
        {
            const string ret = "return ";
            var result = ((IJavaScriptExecutor)driver).ExecuteScript(
                (selector.StartsWith(ret, StringComparison.InvariantCultureIgnoreCase) ? string.Empty : ret) + selector);

            return result as IEnumerable<object>;
        }
    }
}