using FiltersSample.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [ServiceFilter(typeof(CustomFilter))]
        [AnotherCustomFilter("Test1", "Test2", true, 1)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
