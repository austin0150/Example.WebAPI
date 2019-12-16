using Example.Business.Interfaces;
using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business
{
    public class Hex:IHex
    {
        public HexResponse ProccessRequest(HexRequest request)
        {
            string original = request.stringToModify;

            char[] chars = original.ToCharArray();
            string finalOut = "";
            foreach (char conversion in chars)
            {
                finalOut = finalOut + (Convert.ToInt32(conversion)).ToString("X") + " ";
            }

            HexResponse response = new HexResponse();
            response.originalString = original;
            response.modifiedString = finalOut;

            return response;
        }
    }
}
