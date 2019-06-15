using Microsoft.AspNetCore.Authorization;
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
    public class TaxesController : ControllerBase
    {
        private readonly IOptions<KeysConfig> KeyConfiguration;
        private readonly ITaxesApp TaxesApp;

        public TaxesController(IOptions<KeysConfig> keyConfiguration, ITaxesApp taxesApp)
        {
            KeyConfiguration = keyConfiguration;
            TaxesApp = taxesApp;
        }

        [HttpGet]
        [Route("taxajuros")]
        public TaxesVm GetTaxaJuros()
            => TaxesApp.GetTaxaJuros();
    }
}