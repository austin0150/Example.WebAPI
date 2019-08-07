using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business.Models
{
    public class CapitalizeRequest
    {
        public string stringToModify { get; set; }
        public bool trimTrailingWhiteSpace { get; set; }
        public bool trimPrecedingWhiteSpace { get; set; }
        public bool firstCharOnly { get; set; }

    }
}
