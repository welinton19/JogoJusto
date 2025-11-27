using JogoJusto.AppDta;
using JogoJusto.Models;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public UsuarioController(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    [HttpPost]
    public IActionResult CriarUsuario([FromBody] UsuarioModel usuario)
    {
        _jogodbcontext.Usuario.Add(usuario);
        _jogodbcontext.SaveChanges();
        return CreatedAtAction(nameof(User), new { id = usuario.Id }, usuario);
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] UsuarioModel usuario)
    {
        var usuarioExistente = _jogodbcontext.Usuario
            .FirstOrDefault(u => u.Email == usuario.Email && u.Password == usuario.Password);
        if (usuarioExistente == null)
        {
            return Unauthorized("Credenciais inválidas.");
        }
        return Ok("Login bem-sucedido.");
    }

    [HttpGet]
    public IActionResult User()
    {
        var usuarios = _jogodbcontext.Usuario.ToList();
        return Ok(usuarios);
    }
}
