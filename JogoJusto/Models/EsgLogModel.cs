using System.ComponentModel.DataAnnotations;

namespace JogoJusto.Models;

public class EsgLogModel
{
    [Key]
    public int IdEsgLog { get; set; }
    public DepartamentoModel Departamento { get; set; } = new DepartamentoModel();
    public string AcaoRealizada { get; set; } = string.Empty;
    public string Recomendacao { get; set; } = string.Empty;
    public DateTime DataAcao { get; set; }
}
