using Echo.Equipment.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Echo.Equipment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        EquipmentData equip = new EquipmentData();

        // GET: api/Equipment
        [HttpGet]
        public Task<string> Get([FromQuery]string equiptype)
        {
            return equip.getEquipment(equiptype);
        }
    }
}