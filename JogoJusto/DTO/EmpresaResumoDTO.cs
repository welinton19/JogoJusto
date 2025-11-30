using JogoJusto.AppDta;

namespace JogoJusto.DTO;

public class EmpresaResumoDTO
{
    public int EmpresaId { get; set; }
    public string Nome { get; set; }
    public int TotalFuncionarios { get; set; }
    public int TotalDepartamentos { get; set; }
    public int MediaScoreESG { get; set; }
    public decimal ScoreEsg { get; set; }

    internal static AnalysticsDashboradDTO CalcularResumo(JogoJustoDbContext jogoJustoDbContext)
    {
        var resumo = new AnalysticsDashboradDTO();
        var empresa = jogoJustoDbContext.Empresa.FirstOrDefault();
        if (empresa != null) 
        {
            resumo.Empresa = new EmpresaResumoDTO
            {
                EmpresaId = empresa.EmpresaId,
                Nome = empresa.Nome,
                TotalFuncionarios = jogoJustoDbContext.Funcionario.Count(f => f.Departamento.EmpresaId == empresa.EmpresaId),
                TotalDepartamentos = jogoJustoDbContext.Departamento.Count(d => d.EmpresaId == empresa.EmpresaId),
                MediaScoreESG = empresa.MetasEsg.Any() ? (int)empresa.MetasEsg.Average(m => m.ValorAtualMetaEsg) : 0,
                ScoreEsg = (decimal)(empresa.MetasEsg.Any() ? empresa.MetasEsg.Average(m => m.ValorAtualMetaEsg) : 0)
            };
            return resumo;
        }
        return null;

    }
}
