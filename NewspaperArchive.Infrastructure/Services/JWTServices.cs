using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NewspaperArchive.Application.Common.Dtos.User;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperArchive.Infrastructure.Services
{
   //public class JWTServices: IJwt
   // {

   //     private readonly JwtToken _jwtTokenConfig;
   //     private readonly byte[] _secret;
   //     public JWTServices(JwtToken jwtToken , IOptions<JwtToken> jwtoken)
   //     {
   //         _jwtTokenConfig = jwtoken.Value;

   //     }


   //    //public JwtToken Authenticate(userModel objloginModel) {
   //    //     // Users lst = new Users();

   //    //     JwtToken lst = new JwtToken();
   //    //     CheckUserExistDto lsty = new CheckUserExistDto();

   //    //     var jwtTokenHandler = new JwtSecurityTokenHandler();
   //    //     var key = Encoding.ASCII.GetBytes(_jwtTokenConfig.Key);
   //    //     var tokenDescriptor = new SecurityTokenDescriptor
   //    //     {

   //    //         Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {

   //    //            new Claim (ClaimTypes.Name,userModel.username),
   //    //             new Claim (ClaimTypes.Role, "Admin"),
   //    //             //new Claim(ClaimTypes.Version , "V3.1")


   //    //         }),
   //    //         Expires = DateTime.UtcNow.AddDays(2),
   //    //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
   //    //     };
   //    //     var token = jwtTokenHandler.CreateToken(tokenDescriptor);
   //    //     lst.Token = jwtTokenHandler.WriteToken(token);

   //    //     return lst;
           

   //    //     //IEnumerable<JwtToken> lst = new IEnumerable<JwtToken>();
   //    //     //JwtToken obj = new JwtToken();

   //    // }
   // }
}
