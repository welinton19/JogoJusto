using JogoJusto.AppDta;
using JogoJusto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/desenvolvimento")]
public class DesenvolvimentoController : ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public DesenvolvimentoController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarDesenvolvimento([FromBody] DesenvolvimentoModel desenvolvimento)
    {
        _jogodbcontext.Desenvolvimento.Add(desenvolvimento);
        _jogodbcontext.SaveChanges();
        return CreatedAtAction(nameof(DesenvolvimentoModel), new { id = desenvolvimento.IdDesenvolvimento }, desenvolvimento);
    }

    [Authorize]
    [HttpPut]
    public IActionResult AtualizarDesenvolvimento([FromBody] DesenvolvimentoModel desenvolvimento)
    {
        var desenvolvimentoExistente = _jogodbcontext.Desenvolvimento.Find(desenvolvimento.IdDesenvolvimento);
        if (desenvolvimentoExistente == null)
        {
            return NotFound("Desenvolvimento não encontrado.");
        }
        desenvolvimentoExistente.NomeTreinamento = desenvolvimento.NomeTreinamento;
        desenvolvimentoExistente.DuracaoHoras = desenvolvimento.DuracaoHoras;
        desenvolvimentoExistente.DataConclusao = desenvolvimento.DataConclusao;
        desenvolvimentoExistente.StatusRegistro = desenvolvimento.StatusRegistro;
        desenvolvimentoExistente.DescricaoRegistro = desenvolvimento.DescricaoRegistro;
        _jogodbcontext.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetDesenvolvimentos()
    {
        var desenvolvimentos = _jogodbcontext.Desenvolvimento.ToList();
        return Ok(desenvolvimentos);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetDesenvolvimentoPorId(int id)
    {
        var desenvolvimento = _jogodbcontext.Desenvolvimento.Find(id);
        if (desenvolvimento == null)
        {
            return NotFound("Desenvolvimento não encontrado.");
        }
        return Ok(desenvolvimento);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeletarDesenvolvimento(int id)
    {
        var desenvolvimento = _jogodbcontext.Desenvolvimento.Find(id);
        if (desenvolvimento == null)
        {
            return NotFound("Desenvolvimento não encontrado.");
        }
        _jogodbcontext.Desenvolvimento.Remove(desenvolvimento);
        _jogodbcontext.SaveChanges();
        return NoContent();
    }
}
