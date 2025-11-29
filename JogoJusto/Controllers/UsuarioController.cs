using JogoJusto.Auth;
using JogoJusto.Pagination;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly ITokenService _tokenService;
    

    

    public UsuarioController(IUsuarioService service, ITokenService tokenService)
    {
        _service = service;
        _tokenService = tokenService;
    }

    [HttpPost("criar")]
    public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCreateViewModel usuario)
    {
        await _service.CriarUsuario(usuario.Tipo, usuario.Email, usuario.Password);
        return Ok("Usuário criado com sucesso.");
    }




    [HttpPost("login")]
    public IActionResult Login([FromBody] UsuarioLoginViewModel model)
    {
        var usuario = _service.AutenticarUsuario(model.Email, model.Password);

        if (usuario == null)
            return Unauthorized("Credenciais inválidas.");

        var token = _tokenService.GenerateToken((Models.UsuarioModel)usuario);

        return Ok(new
        {
            message = "Login realizado com sucesso",
            token
        });
        
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
