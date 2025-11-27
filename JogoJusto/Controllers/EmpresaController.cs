using JogoJusto.AppDta;
using JogoJusto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/empresa")]
public class EmpresaController : ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public EmpresaController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }


    [Authorize]
    [HttpPost]
    public IActionResult CriarEmpresa([FromBody] EmpresaModel empresa)
    {
        _jogodbcontext.Empresa.Add(empresa);
        _jogodbcontext.SaveChanges();
        return CreatedAtAction(nameof(EmpresaModel), new { id = empresa.EmpresaId }, empresa);
    }

    [Authorize]
    [HttpPut]
    public IActionResult AtualizarEmpresa([FromBody] EmpresaModel empresa)
    {
        var empresaExistente = _jogodbcontext.Empresa.Find(empresa.EmpresaId);
        if (empresaExistente == null)
        {
            return NotFound("Empresa não encontrada.");
        }
        empresaExistente.Nome = empresa.Nome;
        empresaExistente.InscricaoEstadual = empresa.InscricaoEstadual;
        empresaExistente.Endereco = empresa.Endereco;
        empresaExistente.Telefone = empresa.Telefone;
        empresaExistente.Departamentos = empresa.Departamentos;
        _jogodbcontext.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetEmpresas()
    {
        var empresas = _jogodbcontext.Empresa.ToList();
        return Ok(empresas);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetEmpresaPorId(int id)
    {
        var empresa = _jogodbcontext.Empresa.Find(id);
        if (empresa == null)
        {
            return NotFound("Empresa não encontrada.");
        }
        return Ok(empresa);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeletarEmpresa(int id)
    {
        var empresa = _jogodbcontext.Empresa.Find(id);
        if (empresa == null)
        {
            return NotFound("Empresa não encontrada.");
        }
        _jogodbcontext.Empresa.Remove(empresa);
        _jogodbcontext.SaveChanges();
        return NoContent();
    }
}
