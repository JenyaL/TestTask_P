using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using TestProject.Fixtures;
using TestProject.Madals;
using TestProject.Pages;

namespace TestProject.Tests
{
    [TestFixture, Author("Jenya"), Description("Examples")]
    [AllureNUnit]
    class RegisterSpec : RegisterPage
    {
        private RegisterPage registerPage = new RegisterPage();
        private CreateAccountModal createAccountModal = new CreateAccountModal();
        string userName = (string)Users.user ["name"];
        string userPassword = (string)Users.user ["password"];
        string userEmail = (string)Users.user ["email"];

        [TestCase(TestName = "Login user into the system", Description = "User is correct")]
        public void Test1()
        {
            registerPage.RegisterFormIsVisible();
            registerPage.FillUserNameField(userName);
            registerPage.ClickNextButton();
            registerPage.FillPasswordField(userPassword);
            registerPage.ClickNextButton();
            registerPage.FillEmailField(userEmail);
            registerPage.ClickNextButton();
            createAccountModal.AcceptButtonIsDisplayed(true);
        }

        [TestCase(0, "   ", TestName = "Login user into the system with invalid data (spaces)",
            Description = "User name consists of three space")]
        [TestCase(2, null, TestName = "Login user into the system with invalid data (two characters)",
            Description = "User name consists of 2 chars")]
        [TestCase(31, null, TestName = "Login user into the system with invalid data (31 characters)",
            Description = "User name consists of 31 chars")]
        [TestCase(4, ">", TestName = "Login user into the system with invalid data (not accepted characters)", Description = "User name consists of not accepted characters")]
        public void Test2(int a, string b)
        {
            string name;
            name = b != null ? $"{RandomValue(a)}{b}" : RandomValue(a);
            Console.WriteLine("1"+ name + name.Length);
        }
    }
}
