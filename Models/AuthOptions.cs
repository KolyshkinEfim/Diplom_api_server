using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace test_crud.Models
{
    public class AuthOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }

        public int TokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            try
            {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
