using AutoMapper;
using JogoJusto.AppDta;
using JogoJusto.Service;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.Controllers;

[ApiController]
public class TokenController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public TokenController(ITokenService tokenService, IMapper mapper)
    {
        _tokenService = tokenService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("api/token")]
    public IActionResult GetToken()
    {
        _tokenService.GetHashCode();
        return Ok();
    }
}
