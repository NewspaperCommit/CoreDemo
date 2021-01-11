using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewspaperArchive.Application.Services;

namespace NewspaperArchive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home2Controller : ControllerBase
    {
        private readonly IService _repository;
        public Home2Controller(IService repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            int j = 0;
            var kk = _repository.GetUserInfo(j);
            //return View();
            return null;
        }
    }
}
