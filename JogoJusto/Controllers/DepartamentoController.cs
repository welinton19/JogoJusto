using JogoJusto.AppDta;
using JogoJusto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/departamento")]
public class DepartamentoController : ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public DepartamentoController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarDepartamento([FromBody] DepartamentoModel departamento)
    {
        _jogodbcontext.Departamento.Add(departamento);
        _jogodbcontext.SaveChanges();
        return CreatedAtAction(nameof(DepartamentoModel), new { id = departamento.IdDepartamento }, departamento);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetDepartamentos()
    {
        var departamentos = _jogodbcontext.Departamento.ToList();
        return Ok(departamentos);
    }
}
