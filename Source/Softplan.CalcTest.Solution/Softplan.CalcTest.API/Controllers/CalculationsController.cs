using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Softplan.CalcTest.Application.Interfaces;
using Softplan.CalcTest.Application.ViewModels;
using Softplan.CalcTest.Infrastructure.Configurations;

namespace Softplan.CalcTest.API.Controllers
{
    [Route("api")]
    [ApiController]
    //[Authorize]
    public class CalculationsController : ControllerBase
    {
        private readonly IOptions<KeysConfig> KeyConfiguration;
        private readonly ICalculationsApp CalculationsApp;

        public CalculationsController(IOptions<KeysConfig> keyConfiguration, ICalculationsApp calculationsApp)
        {
            KeyConfiguration = keyConfiguration;
            CalculationsApp = calculationsApp;
        }

        [HttpGet]
        [Route("calculajuros")]
        public CalculationsVm GetCalculaJuros(decimal valorInicial, int meses)
        {
            var token = HttpContext.GetTokenAsync("access_token");

            return CalculationsApp.GetCalculaJuros(valorInicial, meses, token.Result);
        }

        [HttpGet]
        [Route("showmethecode")]
        public ShowMeTheCodeVm GetShowMeTheCode()
            => CalculationsApp.GetShowMeTheCode();
    }
}