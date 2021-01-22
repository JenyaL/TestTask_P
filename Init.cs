using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TestProject.Core;

namespace TestProject
{
    public class Init : Helper
    {
        public static IWebDriver driver;
        protected static void setUpChromeDriver()
        {
            driver = new ChromeDriver();
        }

        string url = "https://plarium.com/landings/en/desktop/raid/dragon_fire_a_m_f038_arrow_rdoapp";

        [SetUp]
        [AllureTag("Win 10", "Chrome")]
        public void Setup()
        {
            setUpChromeDriver();
            if (driver != null)
            {
                driver.Manage().Window.Maximize();
            }
            driver.Navigate().GoToUrl(url);
        }

        [OneTimeSetUp]
        public void AllureConfig()
        {
            Environment.SetEnvironmentVariable(
                AllureConstants.ALLURE_CONFIG_ENV_VARIABLE,
                Path.Combine(Environment.CurrentDirectory, AllureConstants.CONFIG_FILENAME));
            var config = AllureLifecycle.Instance.JsonConfiguration;
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [TearDown]
        public void AfterTests()
        {
            driver.Quit();
        }
    }
}