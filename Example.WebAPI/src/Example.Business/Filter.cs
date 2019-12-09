using Example.Business.Interfaces;
using Example.Business.Models;
using Example.Business.RegexUtil;
using Example.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business
{
    class Filter : IFilter
    {
        public FilterResponse ProcessRequest(FilterRequest request)
        {

            string newString = StringParser.generateNewString(request.stringToModify, "filter");

            FilterResponse response = new FilterResponse
            {
                originalString = newString
            };

            return response;
        }

        public void ValidateRequest(FilterRequest request)
        {
            if (request.stringToModify.Length == 0)
                throw new Exception("Please ensure that the string is not empty before proceeding.");
        }
    }
}
