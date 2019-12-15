﻿using System;
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
using Example.DataAccess;

namespace Example.WebAPI.Controllers
{
    [Consumes("application/json")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        IBinary _bin;
        ICapitalize _cap;
        DBInteraction _DB;
        ILowercase _low;

        public ExampleController(ICapitalize cap, DBInteraction db, ILowercase low)
        {
            _cap = cap;
            _DB = db;
            _low = low;
        }

        public ExampleController(IBinary bin, DBInteraction db)
        {
            _bin = bin;
            _DB = db;
        }

        public ExampleController(IBinary bin, DBInteraction db)
        {
            _bin = bin;
            _DB = db;
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

                //Persist word/char stats
                for (int i = 0; i < words.Length; i++)
                {
                    _DB.AddUsedWord(words[i]);
                }
                
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
<<<<<<< Updated upstream
=======
        {
            BinaryResponse binResonse;

            try
            {
                //_bin.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                //Persist word/char stats
                for (int i = 0; i < words.Length; i++)
                {
                    _DB.AddUsedWord(words[i]);
                }

                binResonse = _bin.ProccessRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, binResonse);

        }

        [HttpGet]
        [Route("CharStat")]
        public IActionResult CharStatControl([FromBody] char character)
>>>>>>> Stashed changes
        {
            BinaryResponse binResonse;

            try
            {
                //_bin.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                //Persist word/char stats
                for (int i = 0; i < words.Length; i++)
                {
                    _DB.AddUsedWord(words[i]);
                }

                binResonse = _bin.ProccessRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, binResonse);

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

                //Persist word/char stats
                for (int i = 0; i < words.Length; i++)
                {
                    _DB.AddUsedWord(words[i]);
                }
                
                lowResponse = _low.ProcessRequest(lowercaseRequest);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return StatusCode(200, lowResponse);
        }

    }
}