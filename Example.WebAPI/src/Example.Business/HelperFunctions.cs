using Example.Business.Interfaces;
using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business {
    public class HelperFunctions {
        public int IndexOfNonWhitespace(string source, int startIndex = 0)
        {
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (source != null)
                for (int i = startIndex; i < source.Length; i++)
                    if (!char.IsWhiteSpace(source[i])) return i;
            return -1;
        }
    }
}