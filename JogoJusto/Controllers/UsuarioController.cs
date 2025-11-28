using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.Models;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
    {
        _usuarioService = usuarioService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CriarUsuario([FromBody] UsuarioViewModel usuario)
    {
        _usuarioService.CriarUsuario(usuario.Tipo, usuario.Email, usuario.Password);
        return CreatedAtAction(nameof(CriarUsuario), new { id = usuario.Id }, usuario);

    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] UsuarioViewModel usuario)
    {
        var autenticado = _usuarioService.AutenticarUsuario(usuario.Email, usuario.Password);
        if (autenticado)
        {
            return Ok("Login realizado com sucesso!");
        }
        return Unauthorized("Email ou senha inválidos.");
    }

    [HttpGet]
    public IActionResult User()
    {
        _usuarioService.GetUsuario();
        return Ok();
    }
}
