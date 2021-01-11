using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Model
{
   public class JwtToken
    {

        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string Token { get; set; }
        public string Key { get; set; }
        public int Userid { get; set; }
        public string Firstname { get; set; }
        //public string EmailAddress { get; set; }
        public string Status { get; set; }
    }
}
