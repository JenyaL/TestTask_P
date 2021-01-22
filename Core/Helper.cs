using System;



namespace TestProject.Core
{
    public class Helper
    {
        public string RandomValue(int count)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char [count];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars [i] = chars [random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
