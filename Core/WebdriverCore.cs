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

        public bool ElementDisplayed(By selector)
        {
            try
            {
                driver.FindElement(selector);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClearAndFill(By selector, string text)
        {
            ExplicitWait(selector);
            var element = driver.FindElement(selector);
            element.Clear();
            element.SendKeys(text);
        } 
        
        public void Click(By selector)
        {
            var element = driver.FindElement(selector);
            element.Click();
        }
        
        public string GetText(By selector, int seconds = 10)
        {
            ExplicitWait(selector, seconds);
            string text = driver.FindElement(selector).Text;
            return text;
        }
    }
}
