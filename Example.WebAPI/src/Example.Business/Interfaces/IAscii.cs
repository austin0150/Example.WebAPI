using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business.Interfaces
{
    public interface IAscii
    {
        AsciiResponse ProccessRequest(AsciiRequest request);
        //void ValidateRequest(BinaryRequest request);
    }
}
