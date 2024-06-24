using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVC_Net_8.Controllers
{
    [Route("[controller]")]
    public class LenguajesController : Controller
    {
        private readonly ILogger<LenguajesController> _logger;

        public LenguajesController(ILogger<LenguajesController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Listado")]
        public IActionResult Listado()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}