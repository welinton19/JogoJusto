using JogoJusto.AppDta;
using JogoJusto.DTO;
using JogoJusto.Models;

namespace JogoJusto.Service;

public class AnalyticsService : IAnalyticsService
{
    private readonly JogoJustoDbContext _ctx;

    public AnalyticsService(JogoJustoDbContext ctx)
    {
        _ctx = ctx;
    }

    public DashboardDTO GerarDashboardInteligente()
    {
        var empresa = _ctx.Empresa.FirstOrDefault();
        if (empresa == null)
            throw new Exception("Nenhuma empresa cadastrada.");

        int totalFuncionarios = _ctx.Funcionario.Count();
        int totalDepartamentos = _ctx.Departamento.Count();

        var metasAmbientais = _ctx.MetaEsg
            .Where(m => m.TipoMetaEsg!.ToLower() == "ambiental")
            .ToList();

        var metasSociais = _ctx.MetaEsg
            .Where(m => (m.TipoMetaEsg ?? "")
            .ToLower()
            .Contains("social"))
            .ToList();

        var metasGovernanca = _ctx.MetaEsg
            .AsEnumerable()  
            .Where(m => (m.TipoMetaEsg ?? "")
            .ToLower()
            .Contains("govern"))
            .ToList();


        decimal CalcMedia(List<MetaEsgModel> lista)
            => lista.Any() ? lista.Average(m => m.ValorAtualMetaEsg ?? 0) : 0;

        decimal scoreAmbiental = Math.Round(CalcMedia(metasAmbientais),2);
        decimal scoreSocial = Math.Round(CalcMedia(metasSociais),2);
        decimal scoreGovernanca = Math.Round(CalcMedia(metasGovernanca),2);

        decimal scoreTotal = Math.Round(
            (scoreAmbiental + scoreSocial + scoreGovernanca) / 3, 2);

        string classificacao = scoreTotal switch
        {
            >= 80 => "Excelente",
            >= 60 => "Bom",
            >= 40 => "Regular",
            > 0 => "Crítico",
            _ => "Sem Dados"
        };

        return new DashboardDTO
        {
            EmpresaId = empresa.EmpresaId,
            Nome = empresa.Nome,
            TotalFuncionarios = totalFuncionarios,
            TotalDepartamentos = totalDepartamentos,
            ScoreEsgMedio = scoreTotal,
            Esg = new EsgScoreDTO
            {
                ScoreAmbiental = scoreAmbiental,
                ScoreSocial = scoreSocial,
                ScoreGovernanca = scoreGovernanca,
                ScoreTotal = scoreTotal,
                Classificacao = classificacao
            }
        };
    }
}


