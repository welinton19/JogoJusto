using JogoJusto.AppDta.Repository;
using JogoJusto.Pagination;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;
    private readonly AutoMapper.IMapper _mapper;

    public UsuarioService(IUsuarioRepository repo, AutoMapper.IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public object AutenticarUsuario(string email, string password)
    {
        var usuario = _repo.AutenticarUsuario(email, password);
        if (usuario == null)
            return null;
        return usuario;
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