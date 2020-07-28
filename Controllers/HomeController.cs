using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Echo.Equipment.Api.Models;

namespace Echo.Equipment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        EquipmentData equip = new EquipmentData();

        //Liveness probe
        [HttpGet]
        public Task<string> Get()
        {
            return equip.liveness();
        }

    }

}