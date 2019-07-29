using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.Business;
using Example.Business.Models;

namespace Example.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [Route("[Capitalize]")]
        [HttpGet]
        public IActionResult CapitalizeControl ()
        {
            CapitalizeRequest capRequest = new CapitalizeRequest();

            CapitalizeResponse capResonse = new CapitalizeResponse();

            try
            {
                
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }

            return StatusCode(200, capResonse);
            
        }

    }
}