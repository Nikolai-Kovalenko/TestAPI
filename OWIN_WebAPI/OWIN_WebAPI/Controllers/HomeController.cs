﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OWIN_WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        public IEnumerable<int> GetValues()
        {
            return Enumerable.Range(0, 10);
        }
    }
}
