using Softplan.CalcTest.Application.Interfaces;
using Softplan.CalcTest.Application.ViewModels;
using Softplan.CalcTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.CalcTest.Application.App
{
    public class TaxesApp : ITaxesApp
    {
        private Taxes taxes;

        public TaxesVm GetTaxaJuros()
        {
            taxes = new Taxes();

            return new TaxesVm() { Interest = taxes.Interest };
        }
    }
}
