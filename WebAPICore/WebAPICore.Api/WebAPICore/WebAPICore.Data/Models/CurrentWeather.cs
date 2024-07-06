using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPICore.Data.Models
{
    public class CurrentWeather
    {
        [Key]
        public int ID { get; set; }
        public string Status { get; set; }
        public float Temp { get; set; }
        public string MinTemp { get; set; }
        public float  MaxTemp { get; set; }
    }
}
