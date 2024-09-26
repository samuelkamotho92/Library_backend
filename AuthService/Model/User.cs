using Microsoft.AspNetCore.Identity;

namespace AuthService.Model
{
    public class User:IdentityUser
    {
        public string Email { get; set; }

        public string FullNames { get; set; }
        public string Oid { get; set; }
        public string SubOid { get; set; }
    }
}
