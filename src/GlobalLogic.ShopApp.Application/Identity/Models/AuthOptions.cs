using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GlobalLogic.ShopApp.Application.Identity.Models
{
    public class AuthOptions
    {
        public string Issuer { get; private set; }

        public string Audience { get; private set; }

        public string Key { get; private set; }

        public int Lifetime { get; private set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
