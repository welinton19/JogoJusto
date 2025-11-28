using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_METAS_ESG")]
public class MetaEsgModel
{
    [Key]
    [Column("ID_META")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdMetaEsg { get; set; }

    [MaxLength(60)]
    [Column("TIPO_META")]
    public string? TipoMetaEsg { get; set; }

    [MaxLength(400)]
    [Column("DS_META")]
    public string? DescricaoMetaEsg { get; set; }

    [Required]
    [Column("VL_REFERENCIA", TypeName = "NUMBER(5,2)")]
    public decimal ValorReferenciaMetaEsg { get; set; }

    [Column("VL_ATUAL", TypeName = "NUMBER(5,2)")]
    public decimal ValorAtualMetaEsg { get; set; }


    [Column("DT_ATUALIZACAO", TypeName = "DATE")]
    public DateTime AtualizacaoDados { get; set; }

    [Required]
    [Column("PRAZO_META", TypeName = "DATE")]
    public DateTime PrazoMetaEsg { get; set; }

    [Column("T_EMPRESA_ID_EMPRESA")]
    public int? EmpresaId { get; set; }


    [ForeignKey("EmpresaId")]
    public EmpresaModel? Empresa { get; set; }
}
