using JogoJusto.Service;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IAnalyticsService _analyticsService;
    public DashboardController(IAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }
    [HttpGet("inteligente")]
    public IActionResult ObterDashboardInteligente()
    {
        var dashboard = _analyticsService.GerarDashboardInteligente();
        return Ok(dashboard);
    }
}
