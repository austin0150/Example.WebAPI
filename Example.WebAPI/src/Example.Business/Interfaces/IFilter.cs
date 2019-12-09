using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business.Interfaces
{
    interface IFilter
    {
        FilterResponse ProcessRequest(FilterRequest request);
        void ValidateRequest(FilterRequest request);
    }
}
