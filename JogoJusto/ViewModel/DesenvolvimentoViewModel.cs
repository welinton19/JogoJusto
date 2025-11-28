using JogoJusto.Models;

namespace JogoJusto.ViewModel;

public class DesenvolvimentoViewModel
{
    public int IdDesenvolvimento { get; set; }
    public string TipoRegistro { get; set; } = string.Empty;
    public string DescricaoRegistro { get; set; } = string.Empty;
    public string NomeTreinamento { get; set; } = string.Empty;
    public string Treinamento { get; set; } = string.Empty;
    public DateTime DataConclusao { get; set; }
    public decimal DuracaoHoras { get; set; }
    public byte[] Orgao { get; set; } = Array.Empty<byte>();
    public DateTime DataRegistroDeDados { get; set; }
    public string StatusRegistro { get; set; } = string.Empty;
    public FuncionarioModel Funcionario { get; set; } = new();
}
