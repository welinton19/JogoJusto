using JogoJusto.Models;

namespace JogoJusto.ViewModel;

public class EsgLogViewModel
{
    public int IdEsgLog { get; set; }
    public int DepartamentoId { get; set; }
    public string AcaoRealizada { get; set; } = string.Empty;
    public string Recomendacao { get; set; } = string.Empty;
    public DateTime DataAcao { get; set; }
}
