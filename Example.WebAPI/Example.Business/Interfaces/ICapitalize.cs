using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business.Interfaces
{
    interface ICapitalize
    {
        string ProccessString(CapitalizeRequest request);


    }
}
