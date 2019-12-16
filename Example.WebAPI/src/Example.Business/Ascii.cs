using System;
using System.Text;
using Example.Business.Interfaces;
using Example.Business.Models;
using System.Collections.Generic;

namespace Example.Business
{
    public class Ascii : IAscii
    {
        public AsciiResponse ProccessRequest(AsciiRequest request)
        {
            AsciiResponse response = new AsciiResponse();
            response.originalString = request.stringToModify;
            string stringInProgress = request.stringToModify;
            String responseString = "";

    
            byte[] arr = Encoding.ASCII.GetBytes(stringInProgress);

            foreach (byte bit in arr)
            {
                responseString += (" {0} ", bit, (char)bit);
            }
            response.modifiedString = responseString;

            return response;
        }

    }
}
