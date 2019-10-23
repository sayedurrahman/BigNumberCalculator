
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
        public ActionResult<string> Post([FromBody] CalculationModel dataModel)
        {
            string result = "";
            if (dataModel != null)
                result = CoreService.CalculateAndStore(dataModel.firstNumber, dataModel.secondNumber, dataModel.userName);

            return result;
        }
    }
}
