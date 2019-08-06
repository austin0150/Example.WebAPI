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

            if(request.trimPrecedingWhiteSpave)
            {
                stringInProgress = stringInProgress.TrimStart();
            }
            if(request.trimTrainingWhiteSpace)
            {
                stringInProgress = stringInProgress.TrimEnd();
            }

            if(request.firstCharOnly)
            {
                firstChar = stringInProgress.Substring(0, 0);
                firstChar.ToUpper();
                stringInProgress.Remove(0, 0);
                stringInProgress = firstChar + stringInProgress;
            }
            else
            {
                stringInProgress = stringInProgress.ToUpper();
            }

            response.modifiedString = stringInProgress;

            return response;
        }
    }
}
