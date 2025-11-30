using JogoJusto.AppDta;

namespace JogoJusto.DTO;

public class AnalysticsDashboradDTO
{
    public EmpresaResumoDTO Empresa { get; set; }
    public List<DepartamentoScoreDTO> Departamentos { get; set; }
    public List<FuncionariosStatusDTO> Funcionarios { get; set; }
    public EsgScoreDTO ESG { get; set; }
    public int TotalFuncionarios { get; private set; }
    public decimal? MediaSalarios { get; private set; }
    public int TotalDepartamentos { get; private set; }
    public object ScoreEsg { get; private set; }

    public static AnalysticsDashboradDTO CalcularResumo(JogoJustoDbContext jogoJustoDbContext)
    {
        var empresas = jogoJustoDbContext.Empresa.ToList();
        var funcionarios = jogoJustoDbContext.Funcionario.ToList();
        var departamentos = jogoJustoDbContext.Departamento.ToList();
        var esgLogs = jogoJustoDbContext.EsgLogModel.ToList();

        return new AnalysticsDashboradDTO
        {
            Empresa = empresas.Any() ? new EmpresaResumoDTO
            {
                EmpresaId = empresas.First().EmpresaId,
                Nome = empresas.First().Nome,
                TotalFuncionarios = funcionarios.Count,
                TotalDepartamentos = departamentos.Count,
                MediaScoreESG = esgLogs.Any() ? (int)esgLogs.Average(x => x.Nota) : 0,
                ScoreEsg = esgLogs.Any() ? esgLogs.Average(x => x.Nota) : 0
            } : null,
            TotalFuncionarios = funcionarios.Count,
            MediaSalarios = funcionarios.Any()
                ? funcionarios.Average(x => x.Salario)
                : 0,

            TotalDepartamentos = departamentos.Count,

            ScoreEsg = esgLogs.Any()
                ? esgLogs.Average(x => x.Nota)
                : 0
        };
    }
}
