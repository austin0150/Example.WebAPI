﻿using System;
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
        ICapitalize _cap;
        DBInteraction _DB;
        ILowercase _low;
        IFilter _filter;
        IThesaurus _thesaurus;

        ControllerHelperFunctions helper;

        public ExampleController(ICapitalize cap, DBInteraction db, ILowercase low, IBinary bin)
        {
            _cap = cap;
            _DB = db;
            _low = low;
            _bin = bin;
        }

        // public ExampleController(IBinary bin, DBInteraction db)
        // {
        //     _bin = bin;
        //     _DB = db;
        // }

        [HttpGet]
        [Route("Capitalize")]
        public IActionResult CapitalizeControl ([FromBody] CapitalizeRequest request)
        {
            CapitalizeResponse capResonse;

            try
            {
                _cap.ValidateRequest(request);
                string[] words = request.stringToModify.Split(' ');

                // //Persist word/char stats
                // for (int i = 0; i < words.Length; i++)
                // {
                //     _DB.AddUsedWord(words[i]);
                // }
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

                // //Persist word/char stats
                // for (int i = 0; i < words.Length; i++)
                // {
                //     ThreadStart thread1 = delegate {_DB.AddUsedWord(words[i]); };
                //     //_DB.AddUsedWord(words[i]);
                // }
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

                // //Persist word/char stats
                // for (int i = 0; i < words.Length; i++)
                // {
                //     _DB.AddUsedWord(words[i]);
                // }
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

                // //Persist word/char stats
                // for (int i = 0; i < words.Length; i++)
                // {
                //     _DB.AddUsedWord(words[i]);
                // }
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

    }
}