using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using House_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace House_API.Controllers
{
    [Route("[controller]")]
    public class HouseController : Controller
    {
        [HttpGet]

        public async Task<ActionResult<HouseViewModel>> ListHouses(){

            throw new NotImplementedException();
        }
    }
}