using Example.Business.Interfaces;
using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business
{
    class Capitalize : ICapitalize
    {
        public string ProccessString(CapitalizeRequest request)
        {
            string modifiedString ="";
            if(string.IsNullOrEmpty(request.stringToModify))
            {
                throw new Exception("Input String Cannot be empty");
            }

            return modifiedString;
        }

    }
}
