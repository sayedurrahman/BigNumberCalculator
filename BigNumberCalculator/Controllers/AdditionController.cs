
using BigNumberCalculator.Core;
using BigNumberCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigNumberCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionController : ControllerBase
    {
        private readonly ICoreService CoreService;
        public AdditionController(ICoreService CoreService)
        {
            this.CoreService = CoreService;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] CalculationModel dataModel)
        {
            if (dataModel != null)
                CoreService.CalculateAndStore(dataModel.firstNumber, dataModel.secondNumber, dataModel.userName);

            return Ok();
        }
    }
}
