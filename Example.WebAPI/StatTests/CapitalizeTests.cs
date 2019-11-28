using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Example.Business;
using Example.Business.Models;

namespace StatTests
{
    //[TestFixture]
    class CapitalizeTests
    {
        private CapitalizeRequest request;
        private CapitalizeResponse response;
        private Capitalize cap;

        [SetUp]
        public void Setup()
        {
            request = new CapitalizeRequest();
            cap = new Capitalize();
            response = new CapitalizeResponse();
        }

        [Test]
        public void ValidateBadRequest()
        {
            //arrange
            request.stringToModify = " this is a bad string";
            request.firstCharOnly = true;
            request.trimPrecedingWhiteSpace = false;

            //act
            TestDelegate del = () => cap.ValidateRequest(request);

            //assert
            Assert.That(del, Throws.TypeOf<Exception>(), "Bad request did not throw exception");
        }

        [Test]
        public void ValidateGoodRequest()
        {
            //arrange
            request.stringToModify = "this is a good string";
            request.firstCharOnly = true;
            request.trimPrecedingWhiteSpace = false;

            //act
            TestDelegate del = () => cap.ValidateRequest(request);

            //assert
            Assert.DoesNotThrow(del, "Good request threw exception");
        }

        [Test]
        public void ProccessRequestTrimPreceding()
        {
            //arrange
            request.stringToModify = "    TEST STRING";
            request.firstCharOnly = false;
            request.trimPrecedingWhiteSpace = true;
            request.trimTrailingWhiteSpace = false;

            //act
            response = cap.ProccessRequest(request);

            //assert
            Assert.AreEqual("TEST STRING", response.modifiedString);
        }

        [Test]
        public void ProccessRequestTrimTrailing()
        {
            //arrange
            request.stringToModify = "TEST STRING     ";
            request.firstCharOnly = false;
            request.trimPrecedingWhiteSpace = false;
            request.trimTrailingWhiteSpace = true;

            //act
            response = cap.ProccessRequest(request);

            //assert
            Assert.AreEqual("TEST STRING", response.modifiedString);
        }

        [Test]
        public void ProccessRequestFirstChar()
        {
            //arrange
            request.stringToModify = "test string";
            request.firstCharOnly = true;
            request.trimPrecedingWhiteSpace = false;
            request.trimTrailingWhiteSpace = false;

            //act
            response = cap.ProccessRequest(request);

            //assert
            Assert.AreEqual("Test string", response.modifiedString);
        }
    }
}
