using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoFilters.Models.Services
{
    public class AccountServices : IAccountServices
    {
        public bool CheckCredentials(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || username != password)
                return false;
            return true;
        }

        public IEnumerable<string> GetRolesForUser(string userName)
        {
            if (userName.Equals("john", StringComparison.OrdinalIgnoreCase))
            {
                yield return "admin";
            }
        }
    }
}
