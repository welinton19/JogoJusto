using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_DEPTO")]
public class DepartamentoModel
{
    [Key]
    [Column("ID_DEPTO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDepartamento { get; set; }

    [Required]
    [MaxLength(150)]
    [Column("NM_DEPTO")]
    public string NomeDepartamento { get; set; }= string.Empty;

    [Column("GERENTE_ID")]
    public int? GerenteId { get; set; }

    [Required]
    [Column("T_EMPRESA_ID_EMPRESA")]
    public int EmpresaId { get; set; }

    [ForeignKey("EmpresaId")]
    [InverseProperty("Departamentos")]
    public EmpresaModel Empresa { get; set; }= new();

    [InverseProperty("Departamento")]
    public List<FuncionarioModel> Funcionarios { get; set; } = new();

    [InverseProperty("Departamento")]
    public List<EsgLogModel> EsgLogs { get; set; } = new();
}
