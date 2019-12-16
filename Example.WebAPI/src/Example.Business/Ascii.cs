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
            string original = request.stringToModify;

            char[] chars = original.ToCharArray();
            string finalOut = "";
            foreach (char conversion in chars)
            {
                finalOut = finalOut + (Convert.ToInt32(conversion)) + " ";
            }

            AsciiResponse response = new AsciiResponse();
            response.originalString = original;
            response.modifiedString = finalOut;

            return response;
        }

    }
}
