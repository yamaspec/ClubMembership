using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsyncOperationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LongOperationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(5000);
            return Content("Web API Long Operation Completed");
        }
    }
}
