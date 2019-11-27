using Example.Business.Interfaces;
using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business
{
    public class Capitalize : ICapitalize
    {

        public CapitalizeResponse ProccessRequest(CapitalizeRequest request)
        {
            CapitalizeResponse response = new CapitalizeResponse();
            response.originalString = request.stringToModify;

            string firstChar;
            string stringInProgress = request.stringToModify;

            if(request.trimPrecedingWhiteSpace)
            {
                stringInProgress = stringInProgress.TrimStart();
            }
            if(request.trimTrailingWhiteSpace)
            {
                stringInProgress = stringInProgress.TrimEnd();
            }

            if(request.firstCharOnly)
            {
                firstChar = stringInProgress.Substring(0, 1);
                firstChar = firstChar.ToUpper();
                stringInProgress = stringInProgress.Substring(1);
                stringInProgress = firstChar + stringInProgress;
            }
            else
            {
                stringInProgress = stringInProgress.ToUpper();
            }

            response.modifiedString = stringInProgress;

            return response;
        }

        public void ValidateRequest(CapitalizeRequest request)
        {
            if (request.firstCharOnly && request.stringToModify.StartsWith(' ') && !request.trimPrecedingWhiteSpace)
            {
                throw new Exception("Cannot capitalize the first char if it is a space. Set Trim Preceding White Space true, or remove the preceding spaces from the request");
            }
        }
    }
}
