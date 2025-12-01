namespace JogoJusto.DTO;

public class RankingDiversidadeDTO
{
    public int Posicao { get; set; }
    public string Departamento { get; set; } = string.Empty;
    public int TotalFuncionarios { get; set; }
    public decimal ScoreDiversidade { get; set; }

    public decimal PercentualMulheres { get; set; }
    public decimal PercentualRacial { get; set; }
    public decimal PercentualPCD { get; set; }
    public decimal DiversidadeEtaria { get; set; }
}

