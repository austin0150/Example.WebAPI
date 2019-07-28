using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.Business;

namespace Example.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [Route("[Capitalize]")]
        [HttpGet]
        public JsonResult CapitalizeControl ()
        {
            
        }

    }
}