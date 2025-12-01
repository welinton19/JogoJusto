namespace JogoJusto.ViewModel;

public class DepartamentoViewModel
{
    public int IdDepartamento { get; set; }
    public string NomeDepartamento { get; set; } = string.Empty;

    public int? GerenteId { get; set; }
    public string? GerenteNome { get; set; }

    public int EmpresaId { get; set; }
    public string EmpresaNome { get; set; } = string.Empty;
}
