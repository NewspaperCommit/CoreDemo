using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Common.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using NewspaperArchive.Application.Common.Dtos.User;
using Newtonsoft.Json;

using System.Net;

namespace DemoApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [EnableCors("AllowCors"), Route("api/[controller]")]
    public class Login : ControllerBase
    {
        private readonly ILoginServices _LoginServices;
        private readonly IShoppingCart _ShoppingcartServices;
        private readonly JsonSerializerSettings _serializerSettings;
        //private readonly IJwt _IJwt;
        public Login(ILoginServices loginServices, IShoppingCart ShoppingcartServices)
        {

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            _LoginServices = loginServices;
            _ShoppingcartServices = ShoppingcartServices;
            //_IJwt = repositorijwt;
        }



        [HttpPost("Signin")]
        //[AllowAnonymous]
        public async Task<IActionResult> Signin()
        {
            LoginModel LoginModel = new LoginModel();
            LoginModel.username = "devsd5@gmail.com";
            LoginModel.password = "newspaper";
            Apiresponsemodel objResult = await _LoginServices.ValidateUserLogin(LoginModel);
            //JwtToken jwtmodel = new JwtToken();
            //if (LoginModel.username ="")
            //{

            //    jwtmodel = _IJwt.Authenticate(LoginModel);
                
            //}


         

            return new OkObjectResult(objResult);
        }

        //[HttpGet("GetItemCount")]
        //public async Task<IActionResult> GetItemCount()
        //{
        //    ///ShoppingCartModel objResult = await _ShoppingcartServices.ShoppingCart();
        //    //var result = await _LoginServices.GetItemCount(LoginModel.UserId, 1);

        //    return new OkObjectResult(result);
        //}
    }
}

