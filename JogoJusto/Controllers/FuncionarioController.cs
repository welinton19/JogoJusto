using JogoJusto.Pagination;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/funcionario")]
public class FuncionarioController : ControllerBase
{

    private readonly IFuncionarioService _service;

    public FuncionarioController(IFuncionarioService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] JogoJusto.ViewModel.FuncionarioCreateViewModel vm)
    {
        await _service.CreateAsync(vm);
        return Ok("Funcionário criado com sucesso.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] FuncionarioUpdateViewModel vm)
    {
        if (id != vm.FuncionarioId)
            return BadRequest("Id do funcionario divergente.");

        await _service.UpdateAsync(vm);
        return Ok("Funcionário atualizado com sucesso.");
    }

    [HttpGet]
    public async Task<IActionResult> GetFuncionarios([FromQuery] QueryParameters qp)
    {
        var result = await _service.GetFuncionariosAsync(qp.PageNumber, qp.PageSize);

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var func = await _service.GetByIdAsync(id);

        if (func == null)
            return NotFound("Funcionário não encontrado.");

        return Ok(func);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Funcionário removido com sucesso.");
    }
}
