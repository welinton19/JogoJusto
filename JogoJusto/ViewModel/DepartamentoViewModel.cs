using JogoJusto.Models;
using System.ComponentModel.DataAnnotations;

namespace JogoJusto.ViewModel;

public class DepartamentoViewModel
{
    public int IdDepartamento { get; set; }
    
    public string NomeDepartamento { get; set; } = string.Empty;
    public int GerenteId { get; set; }
    public EmpresaModel Empresa { get; set; } = new();
    public List<FuncionarioModel> Funcionarios { get; set; } = new();
    public List<EsgLogModel> EsgLogs { get; set; } = new();
}
