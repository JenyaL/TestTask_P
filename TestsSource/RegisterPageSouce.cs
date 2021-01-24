
using System;
using System.Collections;
using TestProject.Core;
using TestProject.Fixtures;

namespace TestProject.TestsSource
{
    public class RegisterPageSouce
    {
        Helper helper = new Helper();

        string charsData = (string)Users.user ["charsData"];
        string charsDataException = (string)Users.user ["charsDataException"];
        string emailDataCharacters = (string)Users.user ["emailDataCharacters"];
        string userNameError = (string)ErrorsText.errorText ["userNameError"];
        string passwordError = (string)ErrorsText.errorText ["passwordError"];
        string reqFieldError = (string)ErrorsText.errorText ["reqFieldError"];
        string invalidEmailError = (string)ErrorsText.errorText ["invalidEmailError"];
        string emailUsed = (string)ErrorsText.errorText ["emailUsed"];
        string emailLong = (string)ErrorsText.errorText ["emailLong"];

        public string UserNameTestData(int a, string b)
        {
            string name;
            switch (b)
            {
                case "charsData":
                    name = helper.RandomValue(a, charsData);
                    break;
                case "charsDataException":
                    name = helper.RandomValue(a, charsDataException);
                    break;
                default:
                    name = helper.RandomValue(a, b);
                    break;
            };
            return name;
        }

        public string UserNameErrorTestData(string b)
        {
            string errorText;
            if (b == "")
            {
                errorText = reqFieldError;
            }
            else
            {
                errorText = userNameError;
            }
            return errorText;
        }

        public string PasswordTestData(int a, string b)
        {
            string password;
            string quote = @"""";

            switch (b)
            {
                case "charsData":
                    password = helper.RandomValue(a, charsData);
                    break;
                case "charsDataException":
                    password = helper.RandomValue(a, charsDataException);
                    break;
                case "ramdomDataException":
                    password = $"{helper.RandomValue(a - 1, charsData)}{helper.RandomValue(1, $"{charsDataException}'{quote}")}";
                    break;
                default:
                    password = helper.RandomValue(a, b);
                    break;
            };
            return password;
        }

        public string PasswordErrorTestData(string b)
        {
            string errorText;
            if (b == "")
            {
                errorText = reqFieldError;
            }
            else
            {
                errorText = $"{passwordError} ', \".";
            }
            return errorText;
        }



        public string emailTestData(int a, string b)
        {
            string email;
            
            switch (b)
            {
                case "lowercase":
                    email = $"{helper.RandomValue(a, $"q{charsData}{emailDataCharacters}")}w@{helper.RandomValue(a, $"g{charsData}")}l.com".ToLower();
                    break;
                case "uppercase":
                    email = $"{helper.RandomValue(a, $"q{charsData}{emailDataCharacters}")}w@{helper.RandomValue(a, $"g{charsData}")}l.com".ToUpper();
                    break;
                case "emailUsed":
                    email = $"{helper.RandomValue(a, charsData)}@gmail.com";
                    break;
                case "domainWithoutDots":
                    email = $"{helper.RandomValue(a, charsData)}@gmailcom";
                    break;
                case "email":
                case "emailLong":
                    email = $"{helper.RandomValue(a, charsData)}@gmail.com";
                    break;
                case "domainWithout@":
                    email = $"{helper.RandomValue(a, charsData)}gmail.com";
                    break;
                case "emailSpacesName":
                    email = $"{helper.RandomValue(a, charsData)} qwe@gmail.com";
                    break;
                case "emailSpacesDomain":
                    email = $"{helper.RandomValue(a, charsData)}@{helper.RandomValue(a, charsData)} asd.com";
                    break;
                case "emailWithoutName":
                    email = $"@{helper.RandomValue(a, charsData)}.com";
                    break;
                case "emailWithoutDomain":
                    email = $"{helper.RandomValue(a, charsData)}@";
                    break;
                default:
                    email = helper.RandomValue(a, b);
                    break;
            };
            return email;
        }


        public string emailErrorTestData(string b)
        {
            string errorText;
            switch (b)
            {
                case "      ":
                case "invalidEmailError":
                case "domainWithoutDots":
                case "domainWithout@":
                case "emailSpacesName":
                case "emailSpacesDomain":
                case "emailWithoutName":
                case "emailWithoutDomain":
                    errorText = invalidEmailError;
                    break;
                case "emailUsed":
                    errorText = emailUsed;
                    break;
                case "emailLong":
                    errorText = emailLong;
                    break;
                default:
                    errorText = reqFieldError;
                    break;
            }
            return errorText;
        }
    }
}
