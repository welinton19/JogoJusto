using JogoJusto.AppDta;
using JogoJusto.Models;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/esglog")]
public class EsgLogController : ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public EsgLogController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    [HttpPost]
    public IActionResult CriarEsgLog([FromBody] EsgLogModel esgLog)
    {
        _jogodbcontext.EsgLogModel.Add(esgLog);
        _jogodbcontext.SaveChanges();
        return CreatedAtAction(nameof(EsgLogModel), new { id = esgLog.IdEsgLog }, esgLog);
    }

    [HttpGet]
    public IActionResult GetEsgLogs()
    {
        var esgLogs = _jogodbcontext.EsgLogModel.ToList();
        return Ok(esgLogs);
    }

    [HttpDelete]
    public IActionResult DeleteEsgLogs()
    {
        var esgLogs = _jogodbcontext.EsgLogModel.ToList();
        _jogodbcontext.EsgLogModel.RemoveRange(esgLogs);
        _jogodbcontext.SaveChanges();
        return NoContent();
    }

}
