using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.Models;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/empresa")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _empresaService;
    private readonly IMapper _mapper;

    public EmpresaController(IEmpresaService empresaService, IMapper mapper)
    {
        _empresaService = empresaService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarEmpresa([FromBody] EmpresaViewModel empresa)
    {
        _empresaService.CriarEmpresa(empresa.Nome);
        return CreatedAtAction(nameof(GetEmpresaPorId), new { id = empresa.EmpresaId }, empresa);

    }

    [Authorize]
    [HttpPut]
    public IActionResult AtualizarEmpresa([FromBody] EmpresaViewModel empresa)
    {
        var empresaModel = _mapper.Map<EmpresaModel>(empresa);
        return Ok(empresaModel);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetEmpresas()
    {
        var empresas = _empresaService.GetType();
        return Ok(empresas);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetEmpresaPorId(int id)
    {
        var empresa = _empresaService.Get(id);
        return Ok(empresa);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeletarEmpresa(int id)
    {
        var empresa = _empresaService.Get(id);
        return Ok(empresa);
    }
}
