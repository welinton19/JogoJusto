namespace JogoJusto.ViewModel;

public class EmpresaViewModel
{
    public int EmpresaId { get; set; }
    public string Cnpj { get; set; } = string.Empty;
    public string InscricaoEstadual { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}
