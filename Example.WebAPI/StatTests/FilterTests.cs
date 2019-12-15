using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Example.Business;
using Example.Business.Models;
using NUnit.Framework.Constraints;

namespace StatTests
{
    [TestFixture]
    class FilterTests
    {

        private FilterRequest request;
        private FilterResponse response;
        private Filter filter;
        private LinkedList<string[]> testData;

        [SetUp]
        public void Setup()
        {
            request = new FilterRequest();
            response = new FilterResponse();
            filter = new Filter();
            testData = new LinkedList<string[]>();
            testData.AddLast(new string[] { "d[._\\-,\\\\/* ]*[u* ][._\\-,\\\\/* ]*[c* ][._\\-,\\\\/* ]*k", "yuck", "yuck", "yuck", "yuck" });
            testData.AddLast(new string[] { "s[._\\-,\\\\/* ]*[n* ][._\\-,\\\\/* ]*[i* ][._\\-,\\\\/*]*[t* ][._\\-,\\\\/* ]*[c* ][._\\-,\\\\/*]*hs", "lich", "lich", "lich", "lich" });
        }

        [Test]
        public void ValidateBadRequest()
        {
            //arrange
            request.stringToModify = "";

            //act
            TestDelegate del = () => filter.ValidateRequest(request);

            //assert
            Assert.That(del, Throws.TypeOf<Exception>(), "Bad request did not throw exception");

        }

        [Test]
        public void ValidateGoodRequest()
        {
            //arrange
            request.stringToModify = "This string is not empty.";

            //act
            TestDelegate del = () => filter.ValidateRequest(request);

            //assert
            Assert.DoesNotThrow(del, "Good request threw exception");
        }

        [Test]
        public void ProcessRequestMatchFound()
        {
            //arrange
            request.stringToModify = "That's a duck.";

            //act
            response = filter.ProcessRequest(request,  testData);

            //assert
            Assert.AreEqual("That's a yuck.", response.modifiedString);

        }

        [Test]
        public void ProcessRequestNoMatchFound()
        {
            //arrange
            request.stringToModify = "This is a safe string.";

            //act
            response = filter.ProcessRequest(request, testData);

            //assert
            Assert.AreEqual("This is a safe string.", response.modifiedString);

        }

        [Test]
        public void ProcessRequestMultipleMatchFound()
        {
            //arrange
            request.stringToModify = "What, the duck? You snitch.";

            //act
            response = filter.ProcessRequest(request, testData);

            //assert
            Assert.AreEqual("What, the yuck? You lich.", response.modifiedString);

        }

    }
}