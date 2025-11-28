using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.Models;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/desenvolvimento")]
public class DesenvolvimentoController : ControllerBase
{
    private readonly IDesenvolvimentoService _desenvolvimentoService;
    private readonly IMapper _mapper;

    public DesenvolvimentoController(IDesenvolvimentoService desenvolvimentoService, IMapper mapper)
    {
        _desenvolvimentoService = desenvolvimentoService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarDesenvolvimento([FromBody] DesenvolvimentoViewModel desenvolvimento)
    {
        var desenvolvimentoModel = _mapper.Map<DesenvolvimentoModel>(desenvolvimento);
        _desenvolvimentoService.CriarDesenvolvimento(desenvolvimentoModel);
        return CreatedAtAction(nameof(GetDesenvolvimentoPorId), new { id = desenvolvimentoModel.IdDesenvolvimento }, desenvolvimentoModel);
    }

    [Authorize]
    [HttpPut]
    public IActionResult AtualizarDesenvolvimento([FromBody] DesenvolvimentoViewModel desenvolvimento)
    {
        var desenvolvimentoModel = _mapper.Map<DesenvolvimentoModel>(desenvolvimento);
        _desenvolvimentoService.AtualizarDesenvolvimento(desenvolvimentoModel);
        return NoContent();

    }

    [Authorize]
    [HttpGet]
    public IActionResult GetDesenvolvimentos()
    {
        var desenvolvimentos = _desenvolvimentoService.GetDesenvolvimentos();
        return Ok(desenvolvimentos);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetDesenvolvimentoPorId(int id)
    {
        var desenvolvimento = _desenvolvimentoService.GetDesenvolvimentoPorId(id);
        return Ok(desenvolvimento);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeletarDesenvolvimento(int id)
    {
        var desenvolvimento = _desenvolvimentoService.GetDesenvolvimentoPorId(id);
        return Ok(desenvolvimento);
    }
}
