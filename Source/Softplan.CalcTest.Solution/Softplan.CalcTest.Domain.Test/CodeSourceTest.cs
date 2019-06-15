using Microsoft.VisualStudio.TestTools.UnitTesting;
using Softplan.CalcTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalcTest.Domain.Test
{
    [TestClass]
    public class CodeSourceTest
    {
        [TestMethod()]
        public void SearchCodeSourceTest()
        {
            var codeSource = new CodeSource();

            Assert.IsNotNull(codeSource.URLGitHub);
        }
    }
}
