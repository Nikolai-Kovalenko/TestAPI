using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Proj2_webAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("myGet")]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("Get method");
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void Post([FromQuery] string value)
        {
            _logger.LogInformation("Post method");
        }
    }
}