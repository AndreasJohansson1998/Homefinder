using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HomefinderMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomefinderMvc.Controllers
{

    [Route("[controller]")]
    public class HouseController : Controller
    {
        private readonly IConfiguration _config;
        public HouseController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            try
            {
                var houseService = new HouseServiceModel(_config);

                var houses = await houseService.ListAllHouses();
                return View("Index", houses);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            return View("Details");
        }

    }
}