using JogoJusto.Pagination;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/departamento")]
public class DepartamentoController : ControllerBase
{
    private readonly IDepartamentoService _service;

    public DepartamentoController(IDepartamentoService service)
    {
        _service = service;
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] DepartamentoUpdateViewModel vm)
    {
        if (id != vm.IdDepartamento)
            return BadRequest("Id divergente.");

        await _service.UpdateAsync(vm);
        return Ok("Departamento atualizado com sucesso.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dept = await _service.GetByIdAsync(id);
        return dept == null ? NotFound("Departamento não encontrado.") : Ok(dept);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParameters qp)
    {
        var result = await _service.GetAllAsync(qp.PageNumber, qp.PageSize);

        string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";
        result.NextPage = qp.PageNumber * qp.PageSize < result.TotalCount
            ? $"{baseUrl}?pageNumber={qp.PageNumber + 1}&pageSize={qp.PageSize}"
            : null;

        result.PreviousPage = qp.PageNumber > 1
            ? $"{baseUrl}?pageNumber={qp.PageNumber - 1}&pageSize={qp.PageSize}"
            : null;

        Response.Headers.Add("X-Total-Count", result.TotalCount.ToString());

        return Ok(result);
    }

}
