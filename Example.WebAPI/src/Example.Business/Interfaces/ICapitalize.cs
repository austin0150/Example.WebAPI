using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business.Interfaces
{
    public interface ICapitalize
    {
        CapitalizeResponse ProccessRequest(CapitalizeRequest request);
        void ValidateRequest(CapitalizeRequest request);

    }
}
