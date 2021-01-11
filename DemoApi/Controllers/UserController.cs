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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("AllowCors"), Route("api/[controller]")]
     
    public class UserController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IUser _repository;
        private readonly IEvent _repositoryEvent;
        private readonly IJwt _IJwt;
        public UserController(IUser repository, IEvent repositoryEvent , IJwt repositorijwt, ICountryService countryService)
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            _repository = repository;
            _repositoryEvent = repositoryEvent;
            _IJwt = repositorijwt;
            _countryService = countryService;
        }

        [HttpGet("GetAccount")]
        public async Task<IEnumerable<Users>> GetAccount()
        {
            IEnumerable<Users> lst = await _repository.GetAccountList();
            return lst;
        }

        [HttpPost("CreateAccount")]
        public async Task<Apiresponsemodel> CreateAccount([FromBody] EventModel model)
        {
            Apiresponsemodel objResult = new Apiresponsemodel();
            int result = await _repositoryEvent.CreateEvent(model);
            objResult.Data = result;
            objResult.Status = 200;
            objResult.Message = "Successful";
            return objResult;
         //   return result;
        }

        [HttpGet("GetEvent")]
        
        public async Task<IEnumerable<EventListDTO>> GetEvent()
        {
            IEnumerable<EventListDTO> lst = await _repositoryEvent.GetEventList();
            return lst;
        }

        [HttpPost("Login")]
        public async Task<int> Login([FromBody] LoginDTO model)
        {
            int result = await _repository.Login(model);
            return result;
        }

        [AllowAnonymous]
      //  [HttpPost("AddUser")]
        [HttpPost("AddUser")]
        public async Task<Apiresponsemodel> AddUser([FromBody] Users model)
        {
            Apiresponsemodel objResult = new Apiresponsemodel();
            int result = await _repository.AddUser(model);
            objResult.Data = result;
            objResult.Status = 200;
            objResult.Message = "Successful";
            return objResult;
            //int result = await _repository.AddUser(model);
            //return result;
        }
        
        [HttpGet("GetEventType")]
        public async Task<IEnumerable<EventTypeModel>> GetEventType()
        {
            IEnumerable<EventTypeModel> lst = await _repositoryEvent.GetEventType();
            return lst;
        }
       
        [HttpGet("GetVenueList")]
       
        public async Task<IEnumerable<VenueModel>> GetVenueList()
        {
            IEnumerable<VenueModel> lst = await _repositoryEvent.GetVenueList();
            return lst;
        }
        [HttpPost("Signin")]
        [AllowAnonymous]
        public async Task<JwtToken> CheckUserExist([FromBody] Users user)
        {
            CheckUserExistDto lst = await _repository.CheckUserExist(user);
            JwtToken obj = new JwtToken();
            //if (lst.Status == "true")
            //{ 
                
            // obj =   _IJwt.Authenticate(lst.Userid);
            //    obj.Firstname = lst.Firstname;
            //    obj.Userid = lst.Userid;
            //    obj.Status = lst.Status;

            //}

          
            return obj;
        }


        //[HttpGet("GetAllCountriesWithAbbr")]
        //public async Task<IActionResult> AllCountriesWithAbbr()
        //{
        //    Apiresponsemodel objResult = await _countryService.GetAllCountriesWithAbbr();
        //    return new OkObjectResult(objResult);
        //}
    }
}