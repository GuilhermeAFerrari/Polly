using Microsoft.AspNetCore.Mvc;
using PollyRetry.API.Services;

namespace PollyRetry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollyRetryController : ControllerBase
    {
        private readonly IPollyRetryService _pollyRetryService;

        public PollyRetryController(IPollyRetryService pollyRetryService)
        {
            _pollyRetryService = pollyRetryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _pollyRetryService.TestGetAsync();
            return Ok(result.ToString());
        }
    }
}
