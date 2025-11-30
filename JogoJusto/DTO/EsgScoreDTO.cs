namespace JogoJusto.DTO;

public class EsgScoreDTO
{
    public decimal ScoreAmbiental { get; set; }
    public decimal ScoreSocial { get; set; }
    public decimal ScoreGovernanca { get; set; }
    public decimal ScoreTotal { get; set; }
    public string Classificacao { get; set; } = string.Empty;
}
