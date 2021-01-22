using Newtonsoft.Json.Linq;
using TestProject.Core;

namespace TestProject.Fixtures
{
    public class Users
    {
        public static JObject user = JObject.Parse(@"{
        'name' : 'TestUser',
        'password' : 'uSeR$t1e2sT',
        'email' : 'qwerty_test@gmail.com'
        }");
    }
}
