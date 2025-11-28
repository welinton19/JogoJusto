using JogoJusto.AppDta;

namespace JogoJusto.Service;

public class EmpresaService : IEmpresaService
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public EmpresaService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void AtualizarEmpresa(int id, string nome)
    {
        var empresaExistente = _jogodbcontext.Empresa.Find(id);
    }

    public void CriarEmpresa(string nome)
    {
        var empresa = new Models.EmpresaModel
        {
            Nome = nome
        };
    }

    public void DeletarEmpresa(int id)
    {
        var empresaExistente = _jogodbcontext.Empresa.Find(id);
    }

    public object? Get(int id)
    {
        var empresa = _jogodbcontext.Empresa.Find(id);
        return empresa;
    }

    public object? Get(string nome)
    {
        var empresa = _jogodbcontext.Empresa.FirstOrDefault(e => e.Nome == nome);
        return empresa;
    }
}
