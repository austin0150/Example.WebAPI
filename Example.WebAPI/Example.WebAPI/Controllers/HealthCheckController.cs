using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebAPI.Controllers
{
    [Route("HealthCheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult return200()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //response.StatusCode = HttpResponse(200, "Service is good-n-healthy");
            return StatusCode(200, "Service is good-n-healthy");
        }
    }
}