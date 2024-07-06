using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICore.Data.Context;
using WebAPICore.Data.Models;

namespace WebAPICore.Data.Repository
{
    public class WeatherRepository : IRepository<CurrentWeather>
    {
        private readonly WebAPICoreContext _context;

        public IEnumerable<CurrentWeather> All => _context.Weathers.ToList();

        public WeatherRepository(WebAPICoreContext context)
        {
            _context = context;
        }
        public void Add(CurrentWeather entity)
        {
            _context.Weathers.Add(entity);
        }

        public void Delete(CurrentWeather entity)
        {
            _context.Weathers.Remove(entity);
        }

        public CurrentWeather FindById(int Id)
        {
            return _context.Weathers.FirstOrDefault(e => e.ID == Id);
        }

        public void Update(CurrentWeather entity)
        {
            _context.Weathers.Update(entity);
        }
    }
}
