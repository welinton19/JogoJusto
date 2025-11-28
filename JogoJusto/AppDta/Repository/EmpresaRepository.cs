using JogoJusto.Models;

namespace JogoJusto.AppDta.Repository;

public class EmpresaRepository : IEmpresaRepository
{

    private readonly JogoJustoDbContext _jogodbcontext;

    public EmpresaRepository(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void AtualizarEmpresa(EmpresaModel empresa)
    {
        _jogodbcontext.Empresa.Update(empresa);
        _jogodbcontext.SaveChanges();

    }

    public void CriarEmpresa(EmpresaModel empresa)
    {
        _jogodbcontext.Empresa.Add(empresa);
        _jogodbcontext.SaveChanges();
    }

    public void DeletarEmpresa(int id)
    {
        _jogodbcontext.Empresa.Remove(new EmpresaModel { EmpresaId = id });
    }

    public EmpresaModel GetEmpresaPorId(int id)
    {
        if (id > 0)
        {
            var empresa = _jogodbcontext.Empresa.Find(id);
            if (empresa != null)
            {
                return empresa;
            }
        }
        throw new InvalidOperationException("Empresa não encontrada para o id informado.");
    }

    public void GetEmpresas()
    {
        _jogodbcontext.Empresa.ToList();


    }
}
