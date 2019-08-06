using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.Business;
using Example.Business.Models;
using Example.Business.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Example.WebAPI.Controllers
{
    [Route("[controller]")]
    //[Consumes("application/json")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        ICapitalize _cap;

        public ExampleController(ICapitalize cap)
        {
            _cap = cap;
        }

        [HttpGet]
        public IActionResult CapitalizeControl ([FromBody] CapitalizeRequest request)
        {
            if(request.stringToModify == null)
            {
                return StatusCode(500, "String to Modify cannot be null");
            }

            //var request = JsonConvert.DeserializeObject<CapitalizeRequest>(requestBody);

            CapitalizeResponse capResonse;

            try
            {
                capResonse = _cap.ProccessRequest(request);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message + " --- " + e.StackTrace);
            }

            return StatusCode(200, capResonse);
            
        }

    }
}