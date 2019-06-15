using Softplan.CalcTest.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.CalcTest.Application.Interfaces
{
    public interface ICalculationsApp
    {
        CalculationsVm GetCalculaJuros(decimal valorInicial, int meses, string token);
        ShowMeTheCodeVm GetShowMeTheCode();
    }
}
