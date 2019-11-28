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
     class LowercaseTests
     {
         private LowercaseRequest request;
         private LowercaseResponse response;
         private Lowercase cap;

         [SetUp]
         public void Setup()
         {
             request = new LowercaseRequest();
             cap = new Lowercase();
             response = new LowercaseResponse();
         }

         [Test]
         public void ValidateBadRequest()
         {
             //arrange
             request.stringToModify = " THIS IS A BAD STRING";
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
             request.stringToModify = "THIS IS A GOOD STRING";
             request.firstCharOnly = true;
             request.trimPrecedingWhiteSpace = false;

             //act
             TestDelegate del = () => cap.ValidateRequest(request);

             //assert
             Assert.DoesNotThrow(del, "Good request threw exception");
         }

         [Test]
         public void ProcessRequestTrimPreceding()
         {
             //arrange
             request.stringToModify = "    TEST STRING";
             request.firstCharOnly = false;
             request.trimPrecedingWhiteSpace = true;
             request.trimTrailingWhiteSpace = false;

             //act
             response = cap.ProcessRequest(request);

             //assert
             Assert.AreEqual("test string", response.modifiedString);
         }

         [Test]
         public void ProcessRequestTrimTrailing()
         {
             //arrange
             request.stringToModify = "TEST STRING     ";
             request.firstCharOnly = false;
             request.trimPrecedingWhiteSpace = false;
             request.trimTrailingWhiteSpace = true;

             //act
             response = cap.ProcessRequest(request);

             //assert
             Assert.AreEqual("test string", response.modifiedString);
         }

         [Test]
         public void ProcessRequestFirstChar()
         {
             //arrange
             request.stringToModify = "TEST STRING";
             request.firstCharOnly = true;
             request.trimPrecedingWhiteSpace = false;
             request.trimTrailingWhiteSpace = false;

             //act
             response = cap.ProcessRequest(request);

             //assert
             Assert.AreEqual("tEST STRING", response.modifiedString);
         }
     }
 }