﻿using Example.Business.Interfaces;
using Example.Business.Models;
using Example.Business.RegexUtil;
using Example.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business
{
    public class Thesaurus : IThesaurus
    {

        public ThesaurusResponse ProcessRequest(ThesaurusRequest request)
        {

            string newString = StringParser.generateNewString(request.stringToModify, "THESAURUS");

            ThesaurusResponse response = new ThesaurusResponse
            {
                originalString = request.stringToModify,
                modifiedString = newString
            };

            return response;
        }

        public ThesaurusResponse ProcessRequest(ThesaurusRequest request, LinkedList<string[]> thesaurusList)
        {

            string newString = StringParser.generateNewString(request.stringToModify, thesaurusList);

            ThesaurusResponse response = new ThesaurusResponse
            {
                originalString = request.stringToModify,
                modifiedString = newString
            };

            return response;
        }

        public void ValidateRequest(ThesaurusRequest request)
        {
            if (request.stringToModify.Length == 0)
                throw new Exception("Please ensure that the string is not empty before proceeding.");
        } 
    }
}
