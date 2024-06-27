using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Proj2_webAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("myGet")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void Post([FromQuery] string value)
        {

        }
    }
}