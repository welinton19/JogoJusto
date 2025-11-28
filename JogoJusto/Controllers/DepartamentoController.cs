using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.Models;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/departamento")]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoService _departamentoService;
    private readonly IMapper _mapper;

    

    public DepartamentoController(IDepartamentoService departamentoService, IMapper mapper)
    {
        _departamentoService = departamentoService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public IActionResult CriarDepartamento([FromBody] DepartamentoViewModel departamento)
    {
        
        _departamentoService.CriarDepartamento(departamento.NomeDepartamento);
        return Ok(departamento);
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<DepartamentoViewModel>> GetDepartamentos()
    {
        var departamentos = _departamentoService.GetDepartamentos();
        return Ok(departamentos);       
    }

    
}
