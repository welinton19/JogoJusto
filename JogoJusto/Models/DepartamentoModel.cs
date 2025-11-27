using System.ComponentModel.DataAnnotations;

namespace JogoJusto.Models;

public class DepartamentoModel
{
    [Key]
    public int IdDepartamento { get; set; }
    [MaxLength(150)]
    public string NomeDepartamento { get; set; }= string.Empty;
    public int GerenteId { get; set; }
    public EmpresaModel Empresa { get; set; }=new();
    public List<FuncionarioModel> Funcionarios { get; set; } = new();
    public List<EsgLogModel> EsgLogs { get; set; } = new();
}
