using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Business.Interfaces
{
    public interface IThesaurus
    {
        ThesaurusResponse ProcessRequest(ThesaurusRequest request);
        void ValidateRequest(ThesaurusRequest request);
    }
}
