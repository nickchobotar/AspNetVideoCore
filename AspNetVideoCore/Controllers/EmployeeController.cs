using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetVideoCore.Controllers
{

    [Route("company/[controller]/[action]")] // attribute routing
    public class EmployeeController : Controller
    {
        
        public ContentResult Name()
        {
            return Content ("Jonas");
        }
                
        public string Country()
        {
            return "USA";
        }

        public string Index()
        {
           return "Hello, from the Employee = Employee controller/Index method";
        }

    }
}