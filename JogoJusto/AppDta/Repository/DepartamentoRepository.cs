namespace JogoJusto.AppDta.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly JogoJustoDbContext _jogoJustoDbContext;

    public DepartamentoRepository(JogoJustoDbContext jogoJustoDbContext)
    {
        _jogoJustoDbContext = jogoJustoDbContext;
    }

    public void CriarDepartamento(string nome)
    {
        _jogoJustoDbContext.Departamento.Add(new Models.DepartamentoModel
        {
            NomeDepartamento = nome
             
        });
        _jogoJustoDbContext.SaveChanges();
    }

    public void GetDepartamentos()
    {
        _jogoJustoDbContext.Departamento.ToList();
    }
}
