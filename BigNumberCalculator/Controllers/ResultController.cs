
using BigNumberCalculator.Core;
using BigNumberCalculator.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BigNumberCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ICoreService CoreService;
        public ResultController(ICoreService CoreService)
        {
            this.CoreService = CoreService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<UserCalculation>> Get()
        {
            //CoreService.
            return CoreService.GetAllCalculation();
        }
    }
}
