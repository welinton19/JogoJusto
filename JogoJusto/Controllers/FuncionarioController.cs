using JogoJusto.AppDta;
using JogoJusto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/funcionario")]
public class FuncionarioController: ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;
    public FuncionarioController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarFuncionario([FromBody] FuncionarioModel funcionario)
    {
       var novofunc = _jogodbcontext.Funcionario;
         novofunc.Add(funcionario);
        return Ok(novofunc);
    }

    [Authorize]
    [HttpPut("{id}")]
    public IActionResult AtualizarFuncionario([FromBody] FuncionarioModel funcionario)
    {
        var funcionarioExistente = _jogodbcontext.Funcionario.Find(funcionario.FuncionarioId);
        if (funcionarioExistente == null)
        {
            return NotFound("Funcionário não encontrado.");
        }
        funcionarioExistente.Nome = funcionario.Nome;
        funcionarioExistente.Cargo = funcionario.Cargo;
        funcionarioExistente.Departamento = funcionario.Departamento;
        funcionarioExistente.Mentor = funcionario.Mentor;
        funcionarioExistente.DataContratacao = funcionario.DataContratacao;
        _jogodbcontext.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetFuncionarios()
    {
        var funcionarios = _jogodbcontext.Funcionario.ToList();
        return Ok(funcionarios);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetFuncionarioPorId(int id)
    {
        var funcionario = _jogodbcontext.Funcionario.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionário não encontrado.");
        }
        return Ok(funcionario);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeletarFuncionario(int id)
    {
        var funcionario = _jogodbcontext.Funcionario.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionário não encontrado.");
        }
        _jogodbcontext.Funcionario.Remove(funcionario);
        _jogodbcontext.SaveChanges();
        return NoContent();
    }
}
