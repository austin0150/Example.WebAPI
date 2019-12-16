using Example.Business;
using Example.Business.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatTests
{
    [TestFixture]
    class AsciiTests
    {
        public AsciiRequest request;
        public AsciiResponse response;
        public Ascii ascii;

        [SetUp]
        public void Setup()
        {
            request = new AsciiRequest();
            response = new AsciiResponse();
            ascii = new Ascii();
        }

        [Test]
        public void ValidateDec()
        {
            request.stringToModify = "test";
            response = ascii.ProccessRequest(request);

            Assert.AreEqual("116 101 115 116 ", response.modifiedString);
        }
    }
}
