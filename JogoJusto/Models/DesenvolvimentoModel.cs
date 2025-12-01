using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_DESENV")]
public class DesenvolvimentoModel
{
    [Key]
    [Column("ID_DESENV")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDesenvolvimento { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("TIPO_REGISTRO")]
    public string TipoRegistro { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    [Column("DS_REGISTRO")]
    public string DescricaoRegistro { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("NM_TREINAMENTO")]
    public string NomeTreinamento { get; set; } = string.Empty;

    [MaxLength(150)]
    [Column("PROVEDOR_TREINAMENTO")]
    public string Treinamento { get; set; } = string.Empty;

    [Column("DT_CONCLUSAO", TypeName = "DATE")]
    public DateTime? DataConclusao { get; set; }

    [Column("DURACAO_HORAS", TypeName = "NUMBER(6,2)")]
    public decimal? DuracaoHoras { get; set; }

    [Column("CERTIFICADO", TypeName = "BLOB")]
    public byte[]? Certificado { get; set; }

    [Required]
    [Column("DT_REGISTRO", TypeName = "DATE")]
    public DateTime DataRegistroDeDados { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("ST_REGISTRO")]
    public string StatusRegistro { get; set; } = string.Empty;

    [Required]
    [Column("T_FUNCIONARIO_ID_FUNC")]
    public int FuncionarioId { get; set; }

    [ForeignKey("FuncionarioId")]
    [InverseProperty("Desenvolvimentos")]
    public FuncionarioModel? Funcionario { get; set; }
}
