using System.ComponentModel.DataAnnotations;

namespace JogoJusto.Models;

public class FuncionarioModel
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Genero { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public DateTime DataContratacao { get; set; }
    public string Raca { get; set; } = string.Empty;
    public bool StPcd { get; set; }
    public string TipoPcd { get; set; } = string.Empty;
    [Required]
    [MaxLength(16)]
    public string Cpf { get; set; } = string.Empty;
    public string CargaHoraria { get; set; } = string.Empty;
    public string DescricaoCargaHoraria { get; set; } = string.Empty;
    public decimal Salario { get; set; }
    public FuncionarioModel? Mentor { get; set; }
    public List<FuncionarioModel> Mentorados { get; set; } = new List<FuncionarioModel>();
    public DepartamentoModel Departamento { get; set; } = new DepartamentoModel();
    public List<DesenvolvimentoModel> Desenvolvimentos { get; set; } = new List<DesenvolvimentoModel>();
}
