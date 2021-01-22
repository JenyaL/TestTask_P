using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Allure.Steps;
using TestProject.Core;

namespace TestProject.Pages
{
    class RegisterPage : Init
    {
        //locators
        private By registerForm = By.CssSelector($"[data-widget='form-registration']");
        private By userNameField = By.CssSelector($"[name='userName']");
        private By nextButton = By.XPath($"//*[@data-widget='form-registration']//*[@type='submit']");
        private By passwordField = By.CssSelector($"[name='password']");
        private By emailField = By.CssSelector($"[name='email']");

        //Methods
        private WebdriverCore webDriver = new WebdriverCore();

        [AllureStep("Check register form ss visible")]
        public void RegisterFormIsVisible()
        {
            webDriver.ExplicitWait(registerForm);
            bool ActualResult = webDriver.ElementDisplayed(registerForm);
            Assert.AreEqual(ActualResult, true, "Register form is visible");
        }

        [AllureStep("Fill in the username field")]
        public void FillUserNameField(string userName)
        {
            webDriver.ClearAndFill(userNameField, userName);
        }

        [AllureStep("Click [Next] button")]
        public void ClickNextButton()
        {
            webDriver.Click(nextButton);
        }

        [AllureStep("Fill in the password field")]
        public void FillPasswordField(string password)
        {
            webDriver.ClearAndFill(passwordField, password);
        }
        
        [AllureStep("Fill in the email field")]
        public void FillEmailField(string email)
        {
            webDriver.ClearAndFill(emailField, email);
        }
    }
}
