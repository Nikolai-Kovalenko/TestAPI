using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.Data.Context;
using WebAPICore.Data.Models;
    
namespace WebAPICore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly WebAPICoreContext _context;
        
        public CustomersController(WebAPICoreContext context)
        {
            _context = context;
        }
            
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _context.Customers.FirstOrDefault(u => u.ID == id);
        }

    }
}
 