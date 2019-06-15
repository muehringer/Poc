using Microsoft.VisualStudio.TestTools.UnitTesting;
using Softplan.CalcTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalcTest.Domain.Test
{
    [TestClass]
    public class InterestTest
    {
        [TestMethod()]
        public void CalculationInterestTokenInvalidTest()
        {
            var interest = new Interest(1, 5, "akjdhaskjdhakjdhasjkhdkjahkj");

            Assert.IsNull(interest.CalculationInterest());
        }
    }
}
