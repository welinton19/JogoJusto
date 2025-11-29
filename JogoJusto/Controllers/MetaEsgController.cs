using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.Models;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/metaesg")]
public class MetaEsgController : ControllerBase
{
    private readonly IMetaEsgService _metaEsgService;
    private readonly IMapper _mapper;

    public MetaEsgController(IMetaEsgService metaEsgService, IMapper mapper)
    {
        _metaEsgService = metaEsgService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarMeaEsg([FromBody] MetaEsgViewModel meta)
    {
        var metaModel = _mapper.Map<MetaEsgModel>(meta);
        _metaEsgService.CriarMetaEsg(metaModel);
        return CreatedAtAction(nameof(GetMetaEsg), new { id = metaModel.IdMetaEsg }, metaModel);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetMetaEsg()
    {
        _metaEsgService.GetMetaEsg();
        return Ok();
    }

    [Authorize]
    [HttpPut("{id}")]
    [ValidateAntiForgeryToken]  
    public IActionResult AtualizarMetaEsg([FromBody] MetaEsgModel meta)
    {
        _metaEsgService.AtualizarMetaEsg(meta.IdMetaEsg, meta);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeleteMetaEsg(int id)
    {
        _metaEsgService.DeletarMetaEsg(id);
        return Ok();
    }
}
