using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.Models;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/funcionario")]
public class FuncionarioController: ControllerBase
{
    private readonly IFuncionarioService _funcionarioService;
    private readonly IMapper _mapper;

    public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper)
    {
        _funcionarioService = funcionarioService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarFuncionario([FromBody] FuncionarioViewModel funcionario)
    {
       _funcionarioService.CriarFuncionario(funcionario);
        return CreatedAtAction(nameof(GetFuncionarioPorId), new { id = funcionario.FuncionarioId }, funcionario);


    }

    [Authorize]
    [HttpPut("{id}")]
    public IActionResult AtualizarFuncionario([FromBody] FuncionarioViewModel funcionario)
    {
        _funcionarioService.AtualizarFuncionario(funcionario);
        return Ok(funcionario);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetFuncionarios()
    {
        _funcionarioService.GetFuncionarios();
        return Ok();
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetFuncionarioPorId(int id)
    {
        _funcionarioService.GetFuncionarioPorId(id);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeletarFuncionario(int id)
    {
        _funcionarioService.DeletarFuncionario(id);
        return Ok();
    }
}
