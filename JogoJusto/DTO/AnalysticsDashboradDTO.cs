using JogoJusto.AppDta;

namespace JogoJusto.DTO;

public class AnalysticsDashboradDTO
{
    public int TotalEmpresas { get; set; }
    public int TotalFuncionarios { get; set; }
    public int TotalDepartamentos { get; set; }
    public decimal MediaSalarios { get; set; }
    public double ScoreEsg { get; set; }

    
}
