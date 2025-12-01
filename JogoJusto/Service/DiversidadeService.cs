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

        public async Task<InsightsResponseDTO> GerarInsightsAsync()
        {
            var funcionarios = await _ctx.Funcionario
                .Include(f => f.Departamento)
                .ToListAsync();

            if (!funcionarios.Any())
                throw new Exception("Nenhum funcionário cadastrado.");

            var insights = new List<InsightDTO>();

            var grupos = funcionarios
                .GroupBy(f => f.Departamento.NomeDepartamento)
                .ToList();

            foreach (var g in grupos)
            {
                string depto = g.Key;
                int total = g.Count();
                decimal P(int x) => Math.Round((x * 100m) / total, 2);

                var percMulheres = P(g.Count(f => f.Genero?.ToLower() == "feminino"));
                var percPretos = P(g.Count(f => f.Raca?.ToLower() == "preta"));
                var percPardos = P(g.Count(f => f.Raca?.ToLower() == "parda"));
                var percPcd = P(g.Count(f => f.StPcd));

                if (percMulheres >= 60)
                {
                    insights.Add(new InsightDTO
                    {
                        Descricao = $"O departamento {depto} possui forte presença de liderança feminina.",
                        Detalhes = new InsightDetalheDTO
                        {
                            Departamento = depto,
                            Indicador = "lideranca_feminina",
                            Valor = percMulheres
                        }
                    });
                }

                if (percPretos + percPardos <= 10)
                {
                    insights.Add(new InsightDTO
                    {
                        Descricao = $"O departamento {depto} apresenta baixa representatividade racial.",
                        Detalhes = new InsightDetalheDTO
                        {
                            Departamento = depto,
                            Indicador = "diversidade_racial",
                            Valor = percPretos + percPardos
                        }
                    });
                }

                if (percPcd >= 40)
                {
                    insights.Add(new InsightDTO
                    {
                        Descricao = $"O departamento {depto} é referência em inclusão PCD.",
                        Detalhes = new InsightDetalheDTO
                        {
                            Departamento = depto,
                            Indicador = "inclusao_pcd",
                            Valor = percPcd
                        }
                    });
                }

                if (percMulheres == 0 && percPcd == 0 && percPretos + percPardos == 0)
                {
                    insights.Add(new InsightDTO
                    {
                        Descricao = $"O departamento {depto} demonstra ausência crítica de diversidade.",
                        Detalhes = new InsightDetalheDTO
                        {
                            Departamento = depto,
                            Indicador = "alerta_diversidade",
                            Valor = 0
                        }
                    });
                }
            }

            return new InsightsResponseDTO
            {
                Insights = insights
            };
        }

        public async Task<PagedResult<RankingDiversidadeDTO>> GerarRankingAsync(int pageNumber, int pageSize)
        {
            var funcionarios = await _ctx.Funcionario
                .Include(f => f.Departamento)
                .ToListAsync();

            if (!funcionarios.Any())
                throw new Exception("Nenhum funcionário cadastrado.");

            var ranking = new List<RankingDiversidadeDTO>();

            var grupos = funcionarios
                .GroupBy(f => f.Departamento.NomeDepartamento)
                .ToList();

            foreach (var g in grupos)
            {
                int total = g.Count();
                decimal P(int x) => total == 0 ? 0 : Math.Round((x * 100m) / total, 2);

                var percMulheres = P(g.Count(f => f.Genero!.ToLower() == "feminino"));
                var percRacial = P(g.Count(f => f.Raca!.ToLower() == "parda" || f.Raca!.ToLower() == "preta"));
                var percPCD = P(g.Count(f => f.StPcd));

                var hoje = DateTime.Today;
                int m30 = g.Count(f => f.DataNascimento.HasValue && hoje.Year - f.DataNascimento.Value.Year < 30);
                int e3045 = g.Count(f => f.DataNascimento.HasValue && hoje.Year - f.DataNascimento.Value.Year is >= 30 and <= 45);
                int m45 = g.Count(f => f.DataNascimento.HasValue && hoje.Year - f.DataNascimento.Value.Year > 45);

                var etariaBalance = Math.Round(100m - Math.Abs(P(m30) - P(e3045)) - Math.Abs(P(e3045) - P(m45)), 2);
                if (etariaBalance < 0) etariaBalance = 0;

                var score = Math.Round((percMulheres + percRacial + percPCD + etariaBalance) / 4, 2);

                ranking.Add(new RankingDiversidadeDTO
                {
                    Departamento = g.Key,
                    TotalFuncionarios = total,
                    PercentualMulheres = percMulheres,
                    PercentualRacial = percRacial,
                    PercentualPCD = percPCD,
                    DiversidadeEtaria = etariaBalance,
                    ScoreDiversidade = score
                });
            }

            var ordenado = ranking
                .OrderByDescending(r => r.ScoreDiversidade)
                .ToList();

            int pos = 1;
            foreach (var r in ordenado)
                r.Posicao = pos++;

            var pagedItems = ordenado
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<RankingDiversidadeDTO>
            {
                Items = pagedItems,
                TotalCount = ordenado.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<TreinamentoDTO>> GerarTreinamentosAsync(int pageNumber, int pageSize)
        {

            var funcionarios = await _ctx.Funcionario
                .Include(f => f.Departamento)
                .ToListAsync();

            if (!funcionarios.Any())
                throw new Exception("Nenhum funcionário cadastrado.");

            var hoje = DateTime.Today;

            var porDepto = funcionarios
                .GroupBy(f => f.Departamento.NomeDepartamento)
                .Select(g => new
                {
                    Nome = g.Key,
                    Total = g.Count(),
                    PercentMulheres = g.Count(f => f.Genero?.ToLower() == "feminino") * 100m / g.Count(),
                    PercentRacial = g.Count(f =>
                        f.Raca?.ToLower() == "preta" ||
                        f.Raca?.ToLower() == "parda"
                    ) * 100m / g.Count(),
                    PercentPCD = g.Count(f => f.StPcd == true) * 100m / g.Count(),
                    FaixasIdade = g.Select(f =>
                    {
                        if (!f.DataNascimento.HasValue) return -1;
                        int idade = hoje.Year - f.DataNascimento.Value.Year;
                        return idade;
                    }).ToList()
                })
                .ToList();

            var treinamentos = new List<TreinamentoDTO>();

            var deptosPoucasMulheres = porDepto
                .Where(d => d.PercentMulheres < 20 && d.Total >= 3)
                .ToList();

            if (deptosPoucasMulheres.Any())
            {
                treinamentos.Add(new TreinamentoDTO
                {
                    Titulo = "Viés Inconsciente e Igualdade de Gênero",
                    AreaFoco = "Gênero",
                    Prioridade = "Alta",
                    DepartamentosAfetados = deptosPoucasMulheres.Select(d => d.Nome).ToList(),
                    Motivo = "Departamentos com menos de 20% de mulheres na equipe."
                });
            }

            var deptosSemDiversidadeRacial = porDepto
                .Where(d => d.PercentRacial == 0)
                .ToList();

            if (deptosSemDiversidadeRacial.Any())
            {
                treinamentos.Add(new TreinamentoDTO
                {
                    Titulo = "Cultura Antirracista e Inclusão Étnico-Racial",
                    AreaFoco = "Racial",
                    Prioridade = "Alta",
                    DepartamentosAfetados = deptosSemDiversidadeRacial.Select(d => d.Nome).ToList(),
                    Motivo = "Departamentos sem nenhum colaborador preto ou pardo."
                });
            }

            var deptosSemPCD = porDepto
                .Where(d => d.PercentPCD == 0)
                .ToList();

            if (deptosSemPCD.Any())
            {
                treinamentos.Add(new TreinamentoDTO
                {
                    Titulo = "Inclusão e Acessibilidade no Ambiente de Trabalho",
                    AreaFoco = "PCD",
                    Prioridade = "Média",
                    DepartamentosAfetados = deptosSemPCD.Select(d => d.Nome).ToList(),
                    Motivo = "Departamentos sem colaboradores PCD."
                });
            }

            var ranking = porDepto
                .Select(d => new
                {
                    d.Nome,
                    Score = (d.PercentMulheres + d.PercentRacial + d.PercentPCD) / 3m
                })
                .OrderBy(d => d.Score)
                .ToList();

            var criticos = ranking.Where(r => r.Score < 20).ToList();

            if (criticos.Any())
            {
                treinamentos.Add(new TreinamentoDTO
                {
                    Titulo = "Cultura Inclusiva e Liderança Diversa",
                    AreaFoco = "Cultura Organizacional",
                    Prioridade = "Alta",
                    DepartamentosAfetados = criticos.Select(c => c.Nome).ToList(),
                    Motivo = "Departamentos com score de diversidade abaixo de 20."
                });
            }

            if (treinamentos.Any())
            {
                treinamentos.Add(new TreinamentoDTO
                {
                    Titulo = "Workshop de Diversidade, Equidade e Inclusão",
                    AreaFoco = "Geral",
                    Prioridade = "Média",
                    DepartamentosAfetados = new(), 
                    Motivo = "Indicadores gerais apontam necessidade de reforço de cultura inclusiva."
                });
            }

            int totalCount = treinamentos.Count;

            var items = treinamentos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<TreinamentoDTO>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
           
        }


    };

    

}
