using CheckOn.Business.Abstract;
using CheckOn.Core.Data;
using CheckOn.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Utils.HttpRequest;
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
        ICafeService cafeService;

        public CafesController(ICafeService cafeService)
        {
            this.cafeService = cafeService;
        }

        [HttpGet]
        public async Task<ResponseBase<IEnumerable<Cafe>>> Get()
        {
            Task<List<Cafe>> cafesTask = cafeService.GetList();
            IEnumerable<Cafe> cafes = await cafesTask;
            return new SuccessResponse<IEnumerable<Cafe>>(cafes);
        }

        [HttpGet("{id}")]
        public async Task<ResponseBase<Cafe>> Get(int id)
        {
            Task<Cafe> cafeTask = cafeService.Get(c => c.Id == id);
            Cafe cafe = await cafeTask;
            return new SuccessResponse<Cafe>(cafe);
        }
    }
}
