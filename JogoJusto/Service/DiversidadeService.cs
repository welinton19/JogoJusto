using JogoJusto.AppDta;
using JogoJusto.DTO;
using JogoJusto.Pagination;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.Service
{
    public class DiversidadeService : IDiversidadeService
    {
        private readonly JogoJustoDbContext _ctx;

        public DiversidadeService(JogoJustoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DiversidadeDTO> GerarIndicadoresAsync(int pageNumber, int pageSize)
        {
            var funcionarios = await _ctx.Funcionario
                .Include(f => f.Departamento)
                .ToListAsync();

            if (!funcionarios.Any())
                throw new Exception("Nenhum funcionário cadastrado.");

            int total = funcionarios.Count;

            decimal Perc(int qtd) => Math.Round((qtd * 100m) / total, 2);

            int mulheres = funcionarios.Count(f => f.Genero?.ToLower() == "feminino");
            int homens = funcionarios.Count(f => f.Genero?.ToLower() == "masculino");
            int nb = funcionarios.Count(f => f.Genero?.ToLower().Contains("não-bin") == true);

            int brancos = funcionarios.Count(f => f.Raca?.ToLower() == "branca");
            int pardos = funcionarios.Count(f => f.Raca?.ToLower() == "parda");
            int pretos = funcionarios.Count(f => f.Raca?.ToLower() == "preta");
            int indigenas = funcionarios.Count(f => f.Raca?.ToLower() == "indigena");
            int amarelos = funcionarios.Count(f => f.Raca?.ToLower() == "amarela");

            int pcd = funcionarios.Count(f => f.StPcd == true);
            int naoPcd = total - pcd;

            var hoje = DateTime.Today;

            int menor30 = funcionarios.Count(f =>
            {
                if (!f.DataNascimento.HasValue) return false;
                return hoje.Year - f.DataNascimento.Value.Year < 30;
            });

            int entre30e45 = funcionarios.Count(f =>
            {
                if (!f.DataNascimento.HasValue) return false;
                var idade = hoje.Year - f.DataNascimento.Value.Year;
                return idade >= 30 && idade <= 45;
            });

            int maior45 = funcionarios.Count(f =>
            {
                if (!f.DataNascimento.HasValue) return false;
                return hoje.Year - f.DataNascimento.Value.Year > 45;
            });

            var deptos = funcionarios
                .GroupBy(f => f.Departamento.NomeDepartamento)
                .Select(g =>
                {
                    int tot = g.Count();
                    decimal P(int x) => Math.Round((x * 100m) / tot, 2);

                    return new DiversidadeDepartamentoDTO
                    {
                        NomeDepartamento = g.Key,
                        TotalFuncionarios = tot,
                        PercentualMulheres = P(g.Count(f => f.Genero?.ToLower() == "feminino")),
                        PercentualPardos = P(g.Count(f => f.Raca?.ToLower() == "parda")),
                        PercentualPretos = P(g.Count(f => f.Raca?.ToLower() == "preta")),
                        PercentualPCD = P(g.Count(f => f.StPcd == true))
                    };
                })
                .ToList();

            var paged = deptos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var pagedResult = new PagedResult<DiversidadeDepartamentoDTO>
            {
                Items = paged,
                TotalCount = deptos.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return new DiversidadeDTO
            {
                PercentualMulheres = Perc(mulheres),
                PercentualHomens = Perc(homens),
                PercentualNaoBinario = Perc(nb),

                PercentualBrancos = Perc(brancos),
                PercentualPardos = Perc(pardos),
                PercentualPretos = Perc(pretos),
                PercentualIndigenas = Perc(indigenas),
                PercentualAmarelos = Perc(amarelos),

                PercentualPCD = Perc(pcd),
                PercentualNaoPCD = Perc(naoPcd),

                PercentualMenor30 = Perc(menor30),
                Percentual30a45 = Perc(entre30e45),
                PercentualMaior45 = Perc(maior45),

                Departamentos = pagedResult
            };
        }
    }
}
