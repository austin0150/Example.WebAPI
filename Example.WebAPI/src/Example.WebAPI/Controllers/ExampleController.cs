using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.Business;
using Example.Business.Models;
using Example.Business.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Example.DataAccess;

namespace Example.WebAPI.Controllers
{
    [Consumes("application/json")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        IBinary _bin;
        IAscii _ascii;
        ICapitalize _cap;
        DBInteraction _DB;
        ILowercase _low;
        IFilter _filter;
        IThesaurus _thesaurus;
        IHex _hex;

        ControllerHelperFunctions helper;

        public ExampleController(ICapitalize cap,
            DBInteraction db,
            ILowercase low,
            IBinary bin,
            IAscii ascii,
            IFilter fil,
            IThesaurus thesaurus,
            IHex hex)
        {
            _cap = cap;
            _DB = db;
            _low = low;
            _bin = bin;
            _ascii = ascii;
            _filter = fil;
            _thesaurus = thesaurus;
            _hex = hex;
        }

        [HttpGet]
        [Route("Capitalize")]
        public IActionResult CapitalizeControl ([FromBody] CapitalizeRequest request)
        {
            CapitalizeResponse capResonse;

            try
            {
                _cap.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                Thread thread1 = new Thread(()=>ControllerHelperFunctions.databaseWordTransaction(words, _DB));
                thread1.Start();
                
                capResonse = _cap.ProccessRequest(request);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, capResonse);
            
        }

        [HttpGet]
        [Route("Binary")]
        public IActionResult BinaryControl([FromBody] BinaryRequest request)
        {
            BinaryResponse binResonse;

            try
            {
                //_bin.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                Thread thread1 = new Thread(()=>ControllerHelperFunctions.databaseWordTransaction(words, _DB));
                thread1.Start();

                binResonse = _bin.ProccessRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, binResonse);

        }


        [HttpGet]
        [Route("Hex")]
        public IActionResult HexControl([FromBody] HexRequest request)
        {
            HexResponse hexResonse;

            try
            {
                //_bin.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                Thread thread1 = new Thread(() => ControllerHelperFunctions.databaseWordTransaction(words, _DB));
                thread1.Start();

                hexResonse = _hex.ProccessRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, hexResonse);
        }

        [HttpGet]
        [Route("CharStat")]
        public IActionResult CharStatControl([FromBody] char character)
        {
            int numChars;
            try
            {
                numChars = _DB.GetCharUse(character);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            return StatusCode(200, numChars);
        }

        [HttpGet]
        [Route("WordStat")]
        public IActionResult WordStatControl([FromBody] string word)
        {
            int numWords;
            try
            {
                numWords = _DB.GetWordUse(word);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            return StatusCode(200, numWords);
        }

        [HttpGet]
        [Route("Lowercase")]
        public IActionResult LowercaseControl([FromBody] LowercaseRequest lowercaseRequest)
        {
            LowercaseResponse lowResponse;

            try
            {
                _low.ValidateRequest(lowercaseRequest);
                string[] words = lowercaseRequest.stringToModify.Split(' ');

                Thread thread1 = new Thread(()=>ControllerHelperFunctions.databaseWordTransaction(words, _DB));
                thread1.Start();

                lowResponse = _low.ProcessRequest(lowercaseRequest);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, lowResponse);
        }

        [HttpGet]
        [Route("Filter")]
        public IActionResult FilterControl([FromBody] FilterRequest request)
        {
            FilterResponse filterResonse;

            try
            {
                _filter.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                Thread thread1 = new Thread(() => ControllerHelperFunctions.databaseWordTransaction(words, _DB));
                thread1.Start();

                filterResonse = _filter.ProcessRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, filterResonse);

        }

        [HttpGet]
        [Route("Thesaurus")]
        public IActionResult ThesaurusControl([FromBody] ThesaurusRequest request)
        {
            ThesaurusResponse thesaurusResonse;

            try
            {
                _thesaurus.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                Thread thread1 = new Thread(() => ControllerHelperFunctions.databaseWordTransaction(words, _DB));
                thread1.Start();

                thesaurusResonse = _thesaurus.ProcessRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, thesaurusResonse);

        }

        [HttpGet]
        [Route("Ascii")]
        public IActionResult AsciiControl([FromBody] AsciiRequest request)
        {
            AsciiResponse asciiResponse;

            try
            {
                //_bin.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                Thread thread1 = new Thread(() => ControllerHelperFunctions.databaseWordTransaction(words, _DB));
                thread1.Start();

                asciiResponse = _ascii.ProccessRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, asciiResponse);

        }

    }
}