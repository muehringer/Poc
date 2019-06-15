using Microsoft.VisualStudio.TestTools.UnitTesting;
using Softplan.CalcTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalcTest.Domain.Test
{
    [TestClass]
    public class TaxesTest
    {
        [TestMethod()]
        public void SearchTaxesTest()
        {
            var taxes = new Taxes();

            Assert.IsNotNull(taxes.Interest);
        }
    }
}
