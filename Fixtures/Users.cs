using Newtonsoft.Json.Linq;

namespace TestProject.Fixtures
{
    public static class Users
    {
       public static JObject user = JObject.Parse(@"{
        'name' : 'TestUser',
        'password' : 'uSeR$t1e2sT',
        'email' : 'qwerty_test@gmail.com',
        'charsData' : 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789',
        'charsDataException': '<>',
        'emailDataCharacters': '-_.'
        }");
    }
}
