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
    class ThesaurusTests
    {

        private ThesaurusRequest request;
        private ThesaurusResponse response;
        private Thesaurus thesaurus;
        private LinkedList<string[]> testData;

        [SetUp]
        public void Setup()
        {
            request = new ThesaurusRequest();
            response = new ThesaurusResponse();
            thesaurus = new Thesaurus();
            testData = new LinkedList<string[]>();
            testData.AddLast(new string[] { "good", "alright", "alright", "alright", "alright" });
            testData.AddLast(new string[] { "bad", "crummy", "crummy", "crummy", "crummy" });
        }

        [Test]
        public void ValidateBadRequest()
        {
            //arrange
            request.stringToModify = "";

            //act
            TestDelegate del = () => thesaurus.ValidateRequest(request);

            //assert
            Assert.That(del, Throws.TypeOf<Exception>(), "Bad request did not throw exception");

        }

        [Test]
        public void ValidateGoodRequest()
        {
            //arrange
            request.stringToModify = "This string is not empty.";

            //act
            TestDelegate del = () => thesaurus.ValidateRequest(request);

            //assert
            Assert.DoesNotThrow(del, "Good request threw exception");
        }

        [Test]
        public void ProcessRequestMatchFound()
        {
            //arrange
            request.stringToModify = "That was good.";

            //act
            response = thesaurus.ProcessRequest(request, testData);

            //assert
            Assert.AreEqual("That was alright.", response.modifiedString);

        }

        [Test]
        public void ProcessRequestNoMatchFound()
        {
            //arrange
            request.stringToModify = "This string rocks!";

            //act
            response = thesaurus.ProcessRequest(request, testData);

            //assert
            Assert.AreEqual("This string rocks!",response.modifiedString);

        }

        [Test]
        public void ProcessRequestMultipleMatchFound()
        {
            //arrange
            request.stringToModify = "This test is good, absolutely not bad.";

            //act
            response = thesaurus.ProcessRequest(request, testData);

            //assert
            Assert.AreEqual("This test is alright, absolutely not crummy.", response.modifiedString);

        }

    }
}