using Example.Business;
using Example.Business.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatTests
{
    [TestFixture]
    class HexTests
    {
        public HexRequest request;
        public HexResponse response;
        public Hex hex;

        [SetUp]
        public void Setup()
        {
            request = new HexRequest();
            response = new HexResponse();
            hex = new Hex();
        }

        [Test]
        public void ValidateHex()
        {
            request.stringToModify = "test";
            response = hex.ProccessRequest(request);

            Assert.AreEqual("74 65 73 74 ", response.modifiedString);
        }
    }
}
