
using BigNumberCalculator.Core;
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

        [HttpGet]
        public ActionResult Get()
        {
            CoreService.CalculateAndStore("1", "1", "Sayedur");

            return new JsonResult("Ok");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string firstNumber, string secondNumber, string userName)
        {
            CoreService.CalculateAndStore(firstNumber, secondNumber, userName);
        }
    }
}
