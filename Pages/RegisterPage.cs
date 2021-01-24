using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Allure.Steps;
using TestProject.Core;
using System;

namespace TestProject.Pages
{
    class RegisterPage : Init
    {
        //locators
        private By registerForm = By.CssSelector($"[data-widget='form-registration']");
        private By userNameField = By.CssSelector($"[data-qa-entity='form.registration.steps'] [name='userName']");
        private By nextButton = By.XPath($"//*[@data-widget='form-registration']//*[@type='submit']");
        private By passwordField = By.CssSelector($"[data-qa-entity='form.registration.steps'] [name='password']");
        private By emailField = By.CssSelector($"[data-qa-entity='form.registration.steps'] [name='email']");
        private By errorMessage = By.CssSelector($"[data-qa-entity='form.errorMessage.label']");


        //Methods
        private WebdriverCore webDriver = new WebdriverCore();

        [AllureStep("Check register form is visible")]
        public void RegisterFormIsVisible()
        {
            webDriver.ExplicitWait(registerForm);
            bool actualResult = webDriver.ElementDisplayed(registerForm);
            Assert.AreEqual(actualResult, true, "Register form is visible");
        }

        [AllureStep("Fill in the username field")]
        public void FillUserNameField(string userName)
        {
            Console.WriteLine($"User name = {userName}");
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
            Console.WriteLine($"Password = {password}");
            webDriver.ClearAndFill(passwordField, password);
        }

        [AllureStep("Fill in the email field")]
        public void FillEmailField(string email)
        {
            Console.WriteLine($"Email = {email}");
            webDriver.ClearAndFill(emailField, email);
        }

        [AllureStep("Check [Password] field is displayed")]
        public void PasswordFieldIsDisplayed(bool state)
        {
            bool actualResult = webDriver.ElementDisplayed(passwordField);
            Assert.AreEqual(actualResult, state, "Check [Password] field is displayed");
        }

        [AllureStep("Check error message")]
        public void CheckErrorMessage(string expectedText, bool state = true)
        {
            if (state)
            {
                string actualText = webDriver.GetText(errorMessage);
                Assert.AreEqual(actualText, expectedText, "Check error text");
            }
            bool actualResult = webDriver.ElementDisplayed(errorMessage);
            Assert.AreEqual(actualResult, state, "Check [Error message] is displayed");
        }

        [AllureStep("Check [Email] field is displayed")]
        public void emailFieldIsDisplayed(bool state)
        {
            bool actualResult = webDriver.ElementDisplayed(emailField);
            Assert.AreEqual(actualResult, state, "Check [Email] field is displayed");
        }
    }
}
