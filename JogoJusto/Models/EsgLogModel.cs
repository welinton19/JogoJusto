using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_ESG_LOG")]
public class EsgLogModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_LOG")]
    public int IdEsgLog { get; set; }

    [Required]
    [Column("ID_DEPTO")]
    public int DepartamentoId { get; set; }

    [ForeignKey(nameof(DepartamentoId))]
    [InverseProperty("EsgLogs")]
    public DepartamentoModel Departamento { get; set; } = new DepartamentoModel();

    [MaxLength(100)]
    [Column("TIPO_ACAO")]
    public string AcaoRealizada { get; set; } = string.Empty;

    [MaxLength(500)]
    [Column("RECOMENDACAO")]
    public string Recomendacao { get; set; } = string.Empty;

    [Required]
    [Column("DT_REGISTRO", TypeName = "DATE")]
    public DateTime DataAcao { get; set; }
    
}
