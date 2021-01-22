using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace TestProject.Core
{
    public class WebdriverCore : Init
    {
        public void ExplicitWait(By selector, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement firstResult = wait.Until(e => e.FindElement(selector));
        }

        public bool ElementDisplayed(By selector, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(webDriver => webDriver.FindElement(selector).Displayed);
        }

        public void ClearAndFill(By selector, string text)
        {
            var element = driver.FindElement(selector);
            element.Clear();
            element.SendKeys(text);
        } 
        
        public void Click(By selector)
        {
            var element = driver.FindElement(selector);
            element.Click();
        }
    }
}
