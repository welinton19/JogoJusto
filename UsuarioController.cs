JogoJusto\Controllers\UsuarioController.cs
using JogoJusto.Pagination;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCreateViewModel usuario)
    {
        await _service.CriarUsuario(usuario.Tipo, usuario.Email, usuario.Password);
        return Ok("Usuário criado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginViewModel usuario)
    {
        var token = await _service.AutenticarEGerarTokenAsync(usuario.Email, usuario.Password);

        if (token == null)
        {
            return Unauthorized("Credenciais inválidas.");
        }

        return Ok(new { token });
    }



    [HttpGet]
    public async Task<IActionResult> GetUsuarios([FromQuery] QueryParameters qp)
    {
        var result = await _service.GetUsuariosAsync(qp.PageNumber, qp.PageSize);

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
}
