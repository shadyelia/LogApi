using LogApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogApi.Controllers
{
    [Route("api/logger")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PostInfo(LogVM logVM)
        {
            _logger.LogInformation(logVM.Message,logVM.ControllerName);
            return Ok();
        }

        [Route("/Error")]
        [HttpPost]
        public IActionResult PostError(LogVM logVM)
        {
            _logger.LogError(logVM.Message, logVM.ControllerName);
            return Ok();
        }

        [Route("/Warning")]
        [HttpPost]
        public IActionResult PostWarning(LogVM logVM)
        {
            _logger.LogWarning(logVM.Message, logVM.ControllerName);
            return Ok();
        }
    }
}