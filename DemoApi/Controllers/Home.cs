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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
namespace DemoApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [EnableCors("AllowCors"), Route("api/[controller]")]
    public class Home : ControllerBase
    {

        private readonly ICountryService _countryService;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IHeaderLink _headerLinks;
        private readonly IShoppingCart _shoppingCart;
      
        public Home(IUser repository, IEvent repositoryEvent, ICountryService countryService, IHeaderLink headerLinks, IShoppingCart shoppingCart)
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
           
            _countryService = countryService;
            _headerLinks = headerLinks;
            _shoppingCart = shoppingCart;
        }




        [HttpGet("GetAllCountriesWithAbbr")]
        public async Task<IActionResult> AllCountriesWithAbbr()
        {
            Apiresponsemodel objResult = await _countryService.GetAllCountriesWithAbbr();
            return new OkObjectResult(objResult);
        }

        [HttpGet("GetHeaderLinkssinglecss")]
        public async Task<IActionResult> GetHeaderLinkssinglecss()
        {
            HeaderLinksModel objResult = await _headerLinks.GetHeaderLinkssinglecss();
            return new OkObjectResult(objResult);
        }
        //[HttpGet("GetShoppingCartNavigation")]
        //public async Task<IActionResult> GetShoppingCartNavigation()
        //{
        //    ShoppingCartModel objResult = await _shoppingCart.GetShoppingCartNavigation();
        //    return new OkObjectResult(objResult);
        //}
        //[HttpPost("GetCartDetailsNew")]
        ////[AllowAnonymous]
        //public async Task<IActionResult> GetCartDetailsNew(ShoppingCartContainerInfo objShoppingCartContainerInfo, bool IsRemove)
        //{

        //    // Apiresponsemodel objResult = await _shoppingCart.GetCartDetailsNew(LoginModel);
        //    //var result = await _LoginServices.GetItemCount(LoginModel.UserId, 1);




        //    return new OkObjectResult(objResult);
        //}
    }
}
