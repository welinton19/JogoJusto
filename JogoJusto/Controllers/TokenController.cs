using JogoJusto.AppDta;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
public class TokenController : ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public TokenController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    [HttpGet]
    [Route("api/token")]
    public IActionResult GetToken()
    {
        var token = Guid.NewGuid().ToString();
        return Ok(new { Token = token });
    }
}