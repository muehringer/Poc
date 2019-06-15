using Softplan.CalcTest.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.CalcTest.Domain.Entities
{
    public class Taxes
    {
        public double Interest { get; set; }

        public Taxes()
            => this.Interest = TaxesConst.INTEREST;
    }
}
