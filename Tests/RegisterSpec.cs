using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using TestProject.Fixtures;
using TestProject.Madals;
using TestProject.Pages;
using TestProject.TestsSource;

namespace TestProject.Tests
{
    [TestFixture, Author("Evgeniy Lunyov")]
    [AllureTag("NUnit")]
    [AllureNUnit]
    [AllureFeature("Register page")]
    class RegisterSpec : RegisterPage
    {
        private RegisterPage registerPage = new RegisterPage();
        private CreateAccountModal createAccountModal = new CreateAccountModal();
        private RegisterPageSouce registerPageSouce = new RegisterPageSouce();

        string userName = (string)Users.user ["name"];
        string userPassword = (string)Users.user ["password"];
        string userEmail = (string)Users.user ["email"];
        string charsData = (string)Users.user ["charsData"];

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

        [AllureIssue("№ BUG - 11111", "https://")]
        [TestCase(4, " ", TestName = "Login user into the system with invalid [user name] (spaces)",
            Description = "#BUG - User name consists of three space")]
        [TestCase(2, "charsData", TestName = "Login user into the system with invalid [user name] (two characters)",
            Description = "User name consists of 2 chars")]
        [TestCase(31, "charsData", TestName = "Login user into the system with invalid [user name] (31 characters)",
            Description = "User name consists of 31 chars")]
        [TestCase(4, "charsDataException", TestName = "Login user into the system with invalid [user name] (not accepted characters)", Description = "User name consists of not accepted characters")]
        [TestCase(1, "", TestName = "Login user into the system with invalid [user name] (empty)",
            Description = "User name is empty")]
        public void Test2(int a, string b)
        {

            string name = registerPageSouce.UserNameTestData(a, b);
            string errorText = registerPageSouce.UserNameErrorTestData(b);

            registerPage.RegisterFormIsVisible();
            registerPage.FillUserNameField(name);
            registerPage.ClickNextButton();
            registerPage.CheckErrorMessage(errorText);
            registerPage.PasswordFieldIsDisplayed(false);
        }

        [TestCase(3, "charsData", TestName = "Login user into the system with valid [user name] (3 characters)",
            Description = "User name consists of 3 characters")]
        [TestCase(4, "charsData", TestName = "Login user into the system with valid [user name] (4 characters)",
            Description = "User name consists of 4 characters")]
        [TestCase(30, "charsData", TestName = "Login user into the system with valid [user name] (30 characters)",
            Description = "User name consists of 30 characters")]
        [TestCase(29, "charsData", TestName = "Login user into the system with valid [user name] (29 characters)",
            Description = "User name consists of 29 characters")]
        public void Test3(int a, string b)
        {

            string name = registerPageSouce.UserNameTestData(a, b);
            string errorText = registerPageSouce.UserNameErrorTestData(b);

            registerPage.RegisterFormIsVisible();
            registerPage.FillUserNameField(name);
            registerPage.ClickNextButton();
            registerPage.CheckErrorMessage(errorText, false);
            registerPage.PasswordFieldIsDisplayed(true);
        }


        [TestCase(6, " ", TestName = "Login user into the system with invalid [password] (spaces)",
            Description = "Password consists of (six space)")]
        [TestCase(1, "", TestName = "Login user into the system with invalid [password] (empty)",
            Description = "Password is empty")]
        [TestCase(5, "charsData", TestName = "Login user into the system with invalid [password] (5 characters)",
            Description = "Password consists of (5 characters}")]
        [TestCase(41, "charsData", TestName = "Login user into the system with invalid [password] (41 characters)",
            Description = "Password consists of (41 characters}")]
        [TestCase(10, "ramdomDataException", TestName = "Login user into the system with invalid [password] (not accepted characters)",
            Description = "Password consists of (not accepted characters)")]
        public void Test4(int a, string b)
        {
            string password = registerPageSouce.PasswordTestData(a, b);
            string errorText = registerPageSouce.PasswordErrorTestData(b);

            registerPage.RegisterFormIsVisible();
            registerPage.FillUserNameField($"{userName}{RandomValue(5, charsData)}");
            registerPage.ClickNextButton();
            registerPage.PasswordFieldIsDisplayed(true);
            registerPage.FillPasswordField(password);
            registerPage.ClickNextButton();
            registerPage.CheckErrorMessage(errorText);
            registerPage.PasswordFieldIsDisplayed(true);
            registerPage.emailFieldIsDisplayed(false);
        }

        [TestCase(6, "charsData", TestName = "Login user into the system with valid [password] (6 characters)",
            Description = "Password consists of (6 characters}")]
        [TestCase(7, "charsData", TestName = "Login user into the system with valid [password] (7 characters)",
            Description = "Password consists of (7 characters}")]
        [TestCase(40, "charsData", TestName = "Login user into the system with valid [password] (40 characters)",
            Description = "Password consists of (40 characters}")]
        [TestCase(39, "charsData", TestName = "Login user into the system with valid [password] (39 characters)",
            Description = "Password consists of (39 characters}")]
        public void Test5(int a, string b)
        {
            string password = registerPageSouce.PasswordTestData(a, b);
            string errorText = registerPageSouce.PasswordErrorTestData(b);

            registerPage.RegisterFormIsVisible();
            registerPage.FillUserNameField($"{userName}{RandomValue(5, charsData)}");
            registerPage.ClickNextButton();
            registerPage.PasswordFieldIsDisplayed(true);
            registerPage.FillPasswordField(password);
            registerPage.ClickNextButton();
            registerPage.CheckErrorMessage(errorText, false);
            registerPage.PasswordFieldIsDisplayed(false);
            registerPage.emailFieldIsDisplayed(true);
        }

        [TestCase(6, "      ", TestName = "Login user into the system with invalid [email] (spaces)",
            Description = "Email consists of (six space)")]
        [TestCase(1, "", TestName = "Login user into the system with invalid [email] (empty)",
            Description = "Email is empty")]
        [TestCase(1, "emailUsed", TestName = "Login user into the system with invalid [email] (Email used)",
           Description = "Email used")]
        public void Test6(int a, string b)
        {
            string email = registerPageSouce.emailTestData(a, b);
            string errorText = registerPageSouce.emailErrorTestData(b);


            registerPage.RegisterFormIsVisible();
            registerPage.FillUserNameField(userName);
            registerPage.ClickNextButton();
            registerPage.FillPasswordField(userPassword);
            registerPage.ClickNextButton();
            registerPage.FillEmailField(email);
            registerPage.ClickNextButton();
            registerPage.CheckErrorMessage(errorText);
            createAccountModal.AcceptButtonIsDisplayed(false);
        }

        [TestCase(5, "lowercase", TestName = "Login user into the system with valid [email] (lowercase)",
           Description = "Email lowercase")]
        [TestCase(5, "uppercase", TestName = "Login user into the system with valid [email] (uppercase)",
           Description = "Email uppercase")]
        public void Test7(int a, string b)
        {
            string email = registerPageSouce.emailTestData(a, b);
            string errorText = registerPageSouce.emailErrorTestData(b);


            registerPage.RegisterFormIsVisible();
            registerPage.FillUserNameField(userName);
            registerPage.ClickNextButton();
            registerPage.FillPasswordField(userPassword);
            registerPage.ClickNextButton();
            registerPage.FillEmailField(email);
            registerPage.ClickNextButton();
            registerPage.CheckErrorMessage(errorText, false);
            createAccountModal.AcceptButtonIsDisplayed(true);
        }


    }
}
