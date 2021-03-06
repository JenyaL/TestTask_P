﻿using Newtonsoft.Json.Linq;


namespace TestProject.Fixtures
{
    
    public static class ErrorsText
    {
        public static JObject errorText = JObject.Parse(@"{
        'userNameError' : 'Use 3-30 letters and numbers.',
        'passwordError': 'Use 6-40 symbols, except spaces, <, >,',
        'reqFieldError': 'Field is required.',
        'invalidEmailError': 'Invalid email address.',
        'emailUsed': 'There is already an account registered to this email address.',
        'emailLong': 'Invalid email address. Please verify your email address and try again.'
        }");
    }
}
