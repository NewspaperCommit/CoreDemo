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

namespace NewspaperArchiveApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [EnableCors("AllowCors"), Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IShoppingCart _IShoppingCart;
        public ShoppingCartController(IShoppingCart IShoppingCart)
        {

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            _IShoppingCart = IShoppingCart;
           
        }
        [HttpPost("CalculateTotalPrice")]
        public async Task<IActionResult> CalculateTotalPrice([FromBody]Calculate obj)
        {

            Apiresponsemodel objResult = await _IShoppingCart.CalculateTotalPrice(obj.totalquantity, obj.itemBaseTotalQnty, obj.deductedQuantity, obj.itemQuantity, obj.totalCartDetailCount, obj.count, obj.modelUnitPrice);
            



            return new OkObjectResult(objResult);
        }
    }
}
