
using JogoJusto.Atributtes;
using JogoJusto.Pagination;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/desenvolvimento")]
public class DesenvolvimentoController : ControllerBase
{
    private readonly IDesenvolvimentoService _service;

    public DesenvolvimentoController(IDesenvolvimentoService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize]
    [RoleAuthorize("Admin")]
    public async Task<IActionResult> Criar([FromBody] DesenvolvimentoCreateViewModel vm)
    {
        await _service.CreateAsync(vm);
        return Ok("Registro criado com sucesso.");
    }

    [HttpPut("{id}")]
    [Authorize]
    [RoleAuthorize("Admin")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] DesenvolvimentoUpdateViewModel vm)
    {
        if (id != vm.IdDesenvolvimento)
            return BadRequest("Id divergente.");

        await _service.UpdateAsync(vm);
        return Ok("Registro atualizado com sucesso.");
    }

    [HttpGet("{id}")]
    [Authorize]
    [RoleAuthorize("Admin")]
    public async Task<IActionResult> GetById(int id)
    {
        var dev = await _service.GetByIdAsync(id);

        return dev == null ? NotFound("Registro não encontrado.") : Ok(dev);
    }

    [HttpGet]
    [Authorize]
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
    [Authorize]
    [RoleAuthorize("Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Registro removido com sucesso.");
    }
}

