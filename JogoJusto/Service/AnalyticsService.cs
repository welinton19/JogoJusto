using JogoJusto.AppDta;
using JogoJusto.AppDta.Repository;
using JogoJusto.DTO;
using JogoJusto.Models;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.Service
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly JogoJustoDbContext _ctx;

        public AnalyticsService(JogoJustoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DashboardDTO> GerarDashboardInteligenteAsync()
        {
            var empresa = await _ctx.Empresa.FirstOrDefaultAsync();
            if (empresa == null)
                throw new Exception("Nenhuma empresa cadastrada.");

            int totalFuncionarios = await _ctx.Funcionario.CountAsync();
            int totalDepartamentos = await _ctx.Departamento.CountAsync();

            var metasAmbientais = await _ctx.MetaEsg
                .Where(m => (m.TipoMetaEsg ?? "").ToLower().Contains("ambiental"))
                .ToListAsync();

            var metasSociais = await _ctx.MetaEsg
                .Where(m => (m.TipoMetaEsg ?? "").ToLower().Contains("social"))
                .ToListAsync();

            var metasGovernanca = await _ctx.MetaEsg
                .Where(m =>
                    (m.TipoMetaEsg ?? "").ToLower().Contains("govern"))
                .ToListAsync();

            decimal CalcMedia(List<MetaEsgModel> lista) =>
                lista.Any() ? lista.Average(m => m.ValorAtualMetaEsg ?? 0) : 0;

            var scoreAmbiental = Math.Round(CalcMedia(metasAmbientais), 2);
            var scoreSocial = Math.Round(CalcMedia(metasSociais), 2);
            var scoreGovernanca = Math.Round(CalcMedia(metasGovernanca), 2);

            var scoreTotal = Math.Round(
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
}
