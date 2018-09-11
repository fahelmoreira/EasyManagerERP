using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyManager.WebAPI.Controllers
{
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet, Route("customer/list")]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }
    }
}
