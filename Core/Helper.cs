using System;



namespace TestProject.Core
{
    public class Helper
    {
        public string RandomValue(int count, string chars)
        {
            var finalString = "";
            if (chars != finalString)
            {
                var stringChars = new char [count];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars [i] = chars [random.Next(chars.Length)];
                }

                finalString = new String(stringChars);
            }
            else
            {
                finalString = chars;
            }
            return finalString;
        }
    }
}
