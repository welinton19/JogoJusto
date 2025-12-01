using JogoJusto.Service;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public DashboardController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("inteligente")]
        public async Task<IActionResult> ObterDashboard()
        {
            var result = await _analyticsService.GerarDashboardInteligenteAsync();
            return Ok(result);
        }
    }
}
