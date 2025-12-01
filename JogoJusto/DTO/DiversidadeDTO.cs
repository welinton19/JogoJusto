using JogoJusto.Pagination;

namespace JogoJusto.DTO;

public class DiversidadeDTO
{
    public decimal PercentualMulheres { get; set; }
    public decimal PercentualHomens { get; set; }
    public decimal PercentualNaoBinario { get; set; }

    public decimal PercentualBrancos { get; set; }
    public decimal PercentualPardos { get; set; }
    public decimal PercentualPretos { get; set; }
    public decimal PercentualIndigenas { get; set; }
    public decimal PercentualAmarelos { get; set; }

    public decimal PercentualPCD { get; set; }
    public decimal PercentualNaoPCD { get; set; }

    public decimal PercentualMenor30 { get; set; }
    public decimal Percentual30a45 { get; set; }
    public decimal PercentualMaior45 { get; set; }

    public PagedResult<DiversidadeDepartamentoDTO> Departamentos { get; set; } = new();
}

public class DiversidadeDepartamentoDTO
{
    public string NomeDepartamento { get; set; } = string.Empty;
    public int TotalFuncionarios { get; set; }

    public decimal PercentualMulheres { get; set; }
    public decimal PercentualPardos { get; set; }
    public decimal PercentualPretos { get; set; }
    public decimal PercentualPCD { get; set; }
}
