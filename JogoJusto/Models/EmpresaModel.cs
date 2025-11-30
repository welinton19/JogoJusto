using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_EMPRESA")]
public class EmpresaModel
{
    [Key]
    [Column("ID_EMPRESA")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmpresaId { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("NR_CNPJ")]
    public string Cnpj { get; set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    [Column("NR_INSCRI_EST")]
    public string InscricaoEstadual { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("NM_EMPRESA")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    [Column("END_EMPRESA")]
    public string Endereco { get; set; } = string.Empty;


    [Phone]
    [MaxLength(100)]
    [Column("NR_TELEFONE")]
    public string Telefone { get; set; }= string.Empty;

    [InverseProperty("Empresa")]
    public List<DepartamentoModel> Departamentos { get; set; } = new List<DepartamentoModel>();

    [InverseProperty("Empresa")]
    public List<MetaEsgModel> MetasEsg { get; set; } = new List<MetaEsgModel>();
}
