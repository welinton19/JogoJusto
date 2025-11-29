namespace JogoJusto.ViewModel;

public class FuncionarioViewModel
{
    public int FuncionarioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;

    public int DepartamentoId { get; set; }
    public string? DepartamentoNome { get; set; }

    public int? MentorId { get; set; }
    public string? MentorNome { get; set; }

    public int? GerenteId { get; set; }
    public string? GerenteNome { get; set; }
}
