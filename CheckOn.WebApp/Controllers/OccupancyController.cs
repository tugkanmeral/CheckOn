using CheckOn.WebApp.Models.Occupancy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        // POST api/<OccupancyController>
        [HttpPost]
        public void Post([FromBody] CafeOccupancyModel model)
        {
        }
    }
}
