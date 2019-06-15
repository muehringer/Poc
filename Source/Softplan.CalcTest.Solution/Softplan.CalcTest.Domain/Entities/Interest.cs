using Softplan.CalcTest.Infrastructure.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Softplan.CalcTest.Domain.Entities
{
    public class Interest
    {
        private decimal ValorInicial { get; set; }
        private int Tempo { get; set; }
        private string Token { get; set; }
        public double CompoundInterest { get; set; }

        public Interest(decimal valorInicial, int meses, string token)
        {
            this.ValorInicial = valorInicial;
            this.Tempo = meses;
            this.Token = token;
        }

        public double CalculationInterest()
            => this.CompoundInterest = Math.Truncate(Math.Pow(Convert.ToDouble(this.ValorInicial) * (1 + ProxyAPI.GetTaxesServices(this.Token)), this.Tempo));
    }
}
