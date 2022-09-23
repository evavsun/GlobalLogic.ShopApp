using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GlobalLogic.ShopApp.Application.Identity.Models
{
    public class JwtOptions
    {
        public string Issuer { get;  set; }

        public string Audience { get; set; }

        public string PublicKey { get; set; }

        public int Lifetime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(PublicKey));
        }
    }
}
