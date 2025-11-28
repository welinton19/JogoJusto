using JogoJusto.AppDta;
using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public class DepartamentoService : IDepartamentoService
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public DepartamentoService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void CriarDepartamento(string nome)
    {
        var departamento = new Models.DepartamentoModel
        {
            NomeDepartamento = nome
        };
    }

    public void GestarDepartamento(int nome)
    {
        var departamento = _jogodbcontext.Departamento.Find(nome);
    }

    public IEnumerable<DepartamentoViewModel> GetDepartamentos()
    {
        var departamentos = _jogodbcontext.Departamento.Select(d => new DepartamentoViewModel
        {
            IdDepartamento = d.IdDepartamento,
            NomeDepartamento = d.NomeDepartamento
        }).ToList();
        return departamentos;
    }
}
