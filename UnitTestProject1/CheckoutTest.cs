using System;
using CheckoutKata;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutTest
{
    [TestClass]
    public class CheckoutTests
    {
        CheckoutKata.CheckoutKata ck = new CheckoutKata.CheckoutKata();

        //This test checks that valid item keys have their correct hard-coded value
        [TestMethod]
        public void ValidKeyTestA()
        {
            //Arrangement
            string validKey = "A";
            int expectedListAmount = ck.basket.Count + 1;

            //Act
            ck.Scan(validKey);

            //Assert
            int actualListAmount = ck.basket.Count;
            Assert.AreEqual(expectedListAmount, actualListAmount);  //If the basket amount has increased, then valid scanned items are passed to the basket
        }
        [TestMethod]
        public void ValidKeyTestB()
        {
            //Arrangement
            string validKey = "B";
            int expectedListAmount = ck.basket.Count + 1;

            //Act
            ck.Scan(validKey);

            //Assert
            int actualListAmount = ck.basket.Count;
            Assert.AreEqual(expectedListAmount, actualListAmount);  //If the basket amount has increased, then valid scanned items are passed to the basket
        }
        [TestMethod]
        public void ValidKeyTestC()
        {
            //Arrangement
            string validKey = "C";
            int expectedListAmount = ck.basket.Count + 1;

            //Act
            ck.Scan(validKey);

            //Assert
            int actualListAmount = ck.basket.Count;
            Assert.AreEqual(expectedListAmount, actualListAmount);  //If the basket amount has increased, then valid scanned items are passed to the basket
        }
        [TestMethod]
        public void ValidKeyTestD()
        {
            //Arrangement
            string validKey = "D";
            int expectedListAmount = ck.basket.Count + 1;

            //Act
            ck.Scan(validKey);

            //Assert
            int actualListAmount = ck.basket.Count;
            Assert.AreEqual(expectedListAmount, actualListAmount);  //If the basket amount has increased, then valid scanned items are passed to the basket
        }

        //Invalid keys should be presented by the count of basket remaining the same
        [TestMethod]
        public void OutOfRangeKeyTestH()
        {
            //Arrangement
            string invalidKey = "H";
            int expectedListAmount = ck.basket.Count;

            //Act
            ck.Scan(invalidKey);

            //Assert
            int actualListAmount = ck.basket.Count;
            Assert.AreEqual(expectedListAmount, actualListAmount);  //If the basket amount has stayed the same, the invalid scanned item is not passed to the basket
        }
    }
}
