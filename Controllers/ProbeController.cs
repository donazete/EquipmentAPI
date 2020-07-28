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
    public class ProbeController : ControllerBase
    {
        EquipmentData equip = new EquipmentData();
        //Readiness Probe
        [HttpGet]
        public Task<string> Get()
        {
            Task<string> message = equip.openConnection();
            equip.closeConnection();
            return message;
        }
    }
}