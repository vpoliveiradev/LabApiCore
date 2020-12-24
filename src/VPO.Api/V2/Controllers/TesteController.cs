using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VPO.Api.Controllers;
using VPO.Business.Intefaces;

namespace VPO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        private readonly ILogger _logger;
        public TesteController(ILogger<TesteController> logger,
                               INotificador notificador,
                               IUser appUser) : base(notificador, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {
            _logger.LogInformation("Log de Informação");
            _logger.LogWarning("Log de Aviso");
            _logger.LogError("Log de Erro");
            _logger.LogCritical("Log de Problema Critico");
            return "Sou a versão 2";
        }
    }
}
