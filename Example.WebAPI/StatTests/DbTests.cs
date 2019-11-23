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
    }
}
