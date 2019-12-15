using System;
using System.Collections.Generic;
using System.Text;
using Example.DataAccess;
using NUnit.Framework;

namespace StatTests
{
    [TestFixture]
    class DbTests
    {
        DBInteraction db;

        [SetUp]
        public void Setup()
        {
            db = new DBInteraction();
        }

        [Test]
        public void GetWordUse()
        {
            //Arrange
            int result;
            string word = "string";

            //Act
            result = db.GetWordUse(word);

            //Assert
            Assert.That(result > 0);
        }

        [Test]
        public void GetCharUse()
        {
            //Arrange
            int result;
            char letter = 'e';

            //Act
            result = db.GetCharUse(letter);

            //Assert
            Assert.That(result > 0);
        }

        [Test]
        public void AddWordGood()
        {
            //Arrange
            string word = "hotdog";
            int oldAmt, newAmt;

            //Act
            oldAmt = db.GetWordUse(word);
            db.AddUsedWord(word);
            newAmt = db.GetWordUse(word);


            //Assert
            Assert.That(newAmt == (oldAmt + 1));

        }

        [Test]
        public void AddCharGood()
        {
            //Arrange
            char letter = 'G';
            int oldAmt, newAmt;

            //Act
            oldAmt = db.GetCharUse(letter);
            db.AddUsedChar(letter);
            newAmt = db.GetCharUse(letter);


            //Assert
            Assert.That(newAmt == (oldAmt + 1));

        }

        [Test]
        public void GetThesaurusTableGood()
        {
            //Arrange
            int expectedStringArrays = 4;
            int actualStringArrays;

            //Act
            actualStringArrays = db.GetTable("THESAURUS").Count;

            //Assert
            Assert.That(expectedStringArrays == actualStringArrays);

        }

        [Test]
        public void GetFilterTableGood()
        {
            //Arrange
            int expectedStringArrays = 2;
            int actualStringArrays;

            //Act
            actualStringArrays = db.GetTable("FILTER").Count;

            //Assert
            Assert.That(expectedStringArrays == actualStringArrays);

        }

        [Test]
        public void GetThesaurusTableBad()
        {
            //Arrange
            int expectedStringArrays = 10;
            int actualStringArrays;

            //Act
            actualStringArrays = db.GetTable("THESAURUS").Count;

            //Assert
            Assert.That(expectedStringArrays != actualStringArrays);

        }

        [Test]
        public void GetFilterTableBad()
        {
            //Arrange
            int expectedStringArrays = 11;
            int actualStringArrays;

            //Act
            actualStringArrays = db.GetTable("FILTER").Count;

            //Assert
            Assert.That(expectedStringArrays != actualStringArrays);

        }

        [Test]
        public void ValidateFilterData()
        {
            //Arrange
            string expectedString = "yuck";
            string actualString;

            //Act
            actualString = db.GetTable("FILTER").First.Value[1];

            //Assert
            Assert.That(expectedString == actualString);

        }

        [Test]
        public void ValidateThesaurusData()
        {
            //Arrange
            string expectedString = "crummy";
            string actualString;

            //Act
            actualString = db.GetTable("THESAURUS").First.Value[1];

            //Assert
            Assert.That(expectedString == actualString);

        }
    }
}
