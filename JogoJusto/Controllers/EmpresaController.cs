using JogoJusto.Pagination;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/empresa")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresaController(IEmpresaService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] EmpresaCreateViewModel vm)
    {
        await _service.CreateAsync(vm);
        return Ok("Empresa criada com sucesso.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] EmpresaUpdateViewModel vm)
    {
        if (id != vm.EmpresaId)
            return BadRequest("Id divergente.");

        await _service.UpdateAsync(vm);
        return Ok("Empresa atualizada com sucesso.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var empresa = await _service.GetByIdAsync(id);

        return empresa == null ? NotFound("Empresa não encontrada.") : Ok(empresa);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryParameters qp)
    {
        var result = await _service.GetAllAsync(qp.PageNumber, qp.PageSize);

    string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}";

    result.NextPage = (qp.PageNumber * qp.PageSize < result.TotalCount)
        ? $"{baseUrl}?pageNumber={qp.PageNumber + 1}&pageSize={qp.PageSize}"
        : null;

    result.PreviousPage = (qp.PageNumber > 1)
        ? $"{baseUrl}?pageNumber={qp.PageNumber - 1}&pageSize={qp.PageSize}"
        : null;

    Response.Headers.Add("X-Total-Count", result.TotalCount.ToString());

    return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Empresa removida com sucesso.");
    }
}
