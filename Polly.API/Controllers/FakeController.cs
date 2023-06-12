using Microsoft.AspNetCore.Mvc;

namespace Polly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeController : ControllerBase
    {
        private readonly ILogger<FakeController> _logger;

        public FakeController(ILogger<FakeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult FakeGet()
        {
            _logger.LogInformation("Requisição para o método FakeGet()");
            return Ok("Retorno método FakeGet()");
        }
    }
}
