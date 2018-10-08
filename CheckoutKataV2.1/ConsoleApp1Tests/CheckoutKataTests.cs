using System;
using CheckoutKata;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace CheckoutTest
{
    [TestFixture]
    public class CheckoutTests
    {
        CheckoutKata.CheckoutKata ck = new CheckoutKata.CheckoutKata();

        //This test checks that valid item keys have their correct hard-coded value
        [TestCase("A")]
        [TestCase("B")]
        [TestCase("C")]
        [TestCase("D")]
        public void ValidKeys(string keyName)
        {
            //Arrangement
            string validKey = keyName;
            bool expectedOutcome = true;

            //Act
            ck.PopulateItemsList();

            //Assert
            bool actualOutcome = ck.CheckItemValidation(validKey);
            Assert.AreEqual(expectedOutcome, actualOutcome); 
        }

        //Invalid keys should be presented by the count of basket remaining the same
        [TestCase("W")]
        [TestCase("X")]
        [TestCase("Y")]
        [TestCase("Z")]
        public void OutOfRangeKeyTestH(string keyName)
        {
            //Arrangement
            string invalidKey = keyName;
            bool expectedOutcome = false;

            //Act
            ck.PopulateItemsList();

            //Assert
            bool actualOutcome = ck.CheckItemValidation(invalidKey);
            Assert.AreEqual(expectedOutcome, actualOutcome);  //If the basket amount has stayed the same, the invalid scanned item is not passed to the basket
        }

        [TestCase(1, 50)]
        [TestCase(2, 100)]
        [TestCase(3, 130)]
        [TestCase(4, 180)]
        public void ValuesEqualExpectedOutcomeA(int amountA, int expectedPrice)
        {
            //Arrangement
            Dictionary<string, int> exampleBasket = new Dictionary<string, int>();
            exampleBasket.Add("A", amountA);
            ck.PopulateItemsList();

            int totalPrice = ck.CalculateSpend(exampleBasket);

            Assert.AreEqual(totalPrice, expectedPrice);
        }

        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(1, 0, 0, 0, 50)]
        [TestCase(4, 0, 0, 0, 180)]
        [TestCase(4, 1, 0, 0, 210)]
        [TestCase(4, 2, 0, 0, 225)]
        [TestCase(6, 0, 0, 0, 260)]
        [TestCase(0, 2, 0, 0, 45)]
        [TestCase(0, 3, 0, 0, 75)]
        [TestCase(0, 3, 1, 0, 95)]
        [TestCase(0, 0, 1, 1, 35)]
        [TestCase(0, 0, 1, 2, 50)]
        [TestCase(8, 4, 0, 0, 450)]
        [TestCase(8, 4, 3, 7, 615)]
        public void ValuesEqualExpectedOutcome(int amountA, int amountB, int amountC, int amountD, int expectedPrice)
        {
            //Arrangement
            Dictionary<string, int> exampleBasket = new Dictionary<string, int>();
            exampleBasket.Add("A", amountA);
            exampleBasket.Add("B", amountB);
            exampleBasket.Add("C", amountC);
            exampleBasket.Add("D", amountD);
            ck.PopulateItemsList();

            int totalPrice = ck.CalculateSpend(exampleBasket);

            Assert.AreEqual(totalPrice, expectedPrice);
        }
    }
}