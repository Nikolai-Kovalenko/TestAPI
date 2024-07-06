using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICore.Data.Context;
using WebAPICore.Data.Models;

namespace WebAPICore.Data.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly WebAPICoreContext _context;

        public IEnumerable<Customer> All => _context.Customers.ToList();

        public CustomerRepository(WebAPICoreContext context)
        {
            _context = context;
        }
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }
         
        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }

        public Customer FindById(int Id)
        {
            return _context.Customers.FirstOrDefault(u => u.ID == Id);
        }
    }
}
