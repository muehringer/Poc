using Softplan.CalcTest.Application.Interfaces;
using Softplan.CalcTest.Application.ViewModels;
using Softplan.CalcTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.CalcTest.Application.App
{
    public class CalculationsApp : ICalculationsApp
    {
        private Interest interest;
        private CodeSource codeSource;

        public CalculationsVm GetCalculaJuros(decimal valorInicial, int meses, string token)
        {
            interest = new Interest(valorInicial, meses, token);

            return new CalculationsVm() { CompoundInterest = interest.CompoundInterest };
        }

        public ShowMeTheCodeVm GetShowMeTheCode()
        {
            codeSource = new CodeSource();

            return new ShowMeTheCodeVm() { URLGitHub = codeSource.URLGitHub };
        }
    }
}
