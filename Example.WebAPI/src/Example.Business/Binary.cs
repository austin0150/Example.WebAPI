using System;
using System.Text;
using Example.Business.Interfaces;
using Example.Business.Models;
using System.Collections.Generic;

namespace Example.Business
{
    public class Binary : IBinary
    {
        
            public BinaryResponse ProccessRequest(BinaryRequest request)
            {
                BinaryResponse response = new BinaryResponse();
                response.originalString = request.stringToModify;
        
               string stringInProgress = request.stringToModify;

            byte[] btText;
                btText = System.Text.Encoding.UTF8.GetBytes(stringInProgress);
                Array.Reverse(btText);
            System.Collections.BitArray bit = new System.Collections.BitArray(btText);

                String responseString = "";
                for (int i = bit.Length - 1; i >= 0; i--)
                {
                    if (bit[i] == true)
                    {
                        //response.ModifiedString(1);
                        responseString += "1";
                    }
                    else
                    {
                        //response.ModifiedString(0);
                        responseString += "0";
                    }
                    
                }

                response.modifiedString = responseString;

            return response;
            }
        
    }
}

