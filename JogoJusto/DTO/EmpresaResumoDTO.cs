using JogoJusto.AppDta;

namespace JogoJusto.DTO;

public class EmpresaResumoDTO
{
    public int EmpresaId { get; set; }
    public string Nome { get; set; }
    public int TotalFuncionarios { get; set; }
    public int TotalDepartamentos { get; set; }
    public decimal ScoreEsgMedio { get; set; }
}
