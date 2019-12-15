using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business.Interfaces
{
    public interface ILowercase
    {
        LowercaseResponse ProcessRequest(LowercaseRequest request);
        void ValidateRequest(LowercaseRequest request);

    }
}
