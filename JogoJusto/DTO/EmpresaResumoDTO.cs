using JogoJusto.AppDta;

namespace JogoJusto.DTO;

public class EmpresaResumoDTO
{
    public static AnalysticsDashboradDTO CalcularResumo(JogoJustoDbContext db)
    {
        var empresas = db.Empresa.ToList();
        var funcionarios = db.Funcionario.ToList();
        var departamentos = db.Departamento.ToList();
        var esgLogs = db.EsgLogModel.ToList();

        return new AnalysticsDashboradDTO
        {
            TotalEmpresas = empresas.Count,
            TotalFuncionarios = funcionarios.Count,
            TotalDepartamentos = departamentos.Count,

            MediaSalarios = (decimal)(funcionarios.Any()
                ? funcionarios.Average(f => f.Salario)
                : 0),

            ScoreEsg = (double)(esgLogs.Any()
                ? esgLogs.Average(e => e.Nota)
                : 0)
        };
    }
}
