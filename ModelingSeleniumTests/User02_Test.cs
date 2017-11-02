using System;
using ModelingSeleniumTests.PageObjects;
using ModelingSeleniumTests.SeleniumHelpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ModelingSeleniumTests
{
    [TestFixture]
    public class User02Test
    {
        private IWebDriver _driver;
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            _driver = SeleniumHelper.Driver;
            _baseUrl = "http://czpadztirc.infor.com:9200/BIApplicationManager";
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                // _driver.Quit();
                // _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
        }

        [Test]
        public void Login()
        {
            var dashbordsPage = new LoginApplicationPage(_driver).LoginAs(_baseUrl, "admin", "infor");
            var modelingPage = dashbordsPage.DashboardsContentConnectionClick();
            modelingPage.SelectCubesClick();
        }
    }
}