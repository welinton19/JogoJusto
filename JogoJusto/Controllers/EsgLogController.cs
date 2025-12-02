using AutoMapper;
using JogoJusto.Atributtes;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/esglog")]
public class EsgLogController : ControllerBase
{
    private readonly IEsgLogService _esglogservice;
    private readonly IMapper _mapper;

    public EsgLogController(IEsgLogService esglogservice, IMapper mapper)
    {
        _esglogservice = esglogservice;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    [RoleAuthorize("Admin")]
    public IActionResult CriarEsgLog([FromBody] EsgLogViewModel esgLog)
    {
        _esglogservice.CriarEsgLog(esgLog);
        return Ok("Log ESG criado com sucesso.");
    }

    [HttpGet]
    [Authorize]
    [RoleAuthorize("Admin")]
    public IActionResult GetEsgLogs()
    {
        var esgLogs = _esglogservice.GetEsgLogs();
        return Ok(esgLogs);
    }
}
