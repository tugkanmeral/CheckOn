using CheckOn.Business.Abstract;
using CheckOn.Core.Data;
using CheckOn.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = UserRoleNames.USER)]
    public class CafesController : ControllerBase
    {
        ICafeService _cafeService;

        public CafesController(ICafeService cafeService)
        {
            _cafeService = cafeService;
        }

        // GET: api/<CafesController>
        [HttpGet]
        public IEnumerable<Cafe> Get()
        {
            return _cafeService.GetList();
        }

        // GET api/<CafesController>/5
        [HttpGet("{id}")]
        public Cafe Get(int id)
        {
            return _cafeService.Get(c => c.Id == id);
        }

        // PUT api/<CafesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CafesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
