JogoJusto\Service\UsuarioService.cs
using JogoJusto.AppDta.Repository;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;
    private readonly AutoMapper.IMapper _mapper;
    private readonly ITokenService _tokenService;

    public UsuarioService(IUsuarioRepository repo, AutoMapper.IMapper mapper, ITokenService tokenService)
    {
        _repo = repo;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public bool AutenticarUsuario(string email, string senha)
    {
        return _repo.Login(email, senha);
    }

    public async Task<string?> AutenticarEGerarTokenAsync(string email, string senha)
    {
        var valid = _repo.Login(email, senha);
        if (!valid)
            return null;

        var usuario = await _repo.GetByEmailAsync(email);
        if (usuario == null)
            return null;

        // Usa o ITokenService já existente para gerar o token.
        return _tokenService.CreateToken(usuario.Id, usuario.Email);
    }

    public async Task CriarUsuario(string tipo, string email, string senha)
    {
        await _repo.CriarUsuarioAsync(email, senha, tipo);
    }

    public async Task<PagedResult<UsuarioViewModel>> GetUsuariosAsync(int pageNumber, int pageSize)
    {
        var paged = await _repo.GetUsuariosAsync(pageNumber, pageSize);

        var vmItems = paged.Items.Select(u => _mapper.Map<UsuarioViewModel>(u));

        return new PagedResult<UsuarioViewModel>
        {
            PageNumber = paged.PageNumber,
            PageSize = paged.PageSize,
            TotalCount = paged.TotalCount,
            Items = vmItems
        };
    }

}