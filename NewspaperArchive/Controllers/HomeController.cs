using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;

namespace NewspaperArchive.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _repository;
        public HomeController(IService repository)
        {
            _repository = repository;
        }
       
        //public IActionResult Index()
        //{
        //    int j = 0;
        //    var kk = _repository.GetUserInfo(j);
        //    return View();
        //}
        [HttpGet, Route("GetOrCreate")]
        public async Task<IActionResult> GetOrCreate(int id)
        {
            return Ok(await _repository.GetUserInfo(id));
        }
    }
}
