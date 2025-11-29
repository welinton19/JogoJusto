using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_FUNCIONARIO")]
public class FuncionarioModel
{
    [Key]
    [Column("ID_FUNC")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FuncionarioId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("NM_FUNC")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [Column("DT_NASC_FUN", TypeName ="DATE")]
    public DateTime DataNascimento { get; set; }

    [Required]
    [MaxLength(30)]
    [Column("GENERO_FUN")]
    public string Genero { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("CARGO_FUN")]
    public string Cargo { get; set; } = string.Empty;

    [Required]
    [Column("DT_ADMISSAO",TypeName = "DATE")]
    public DateTime DataContratacao { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("COR_FUN")]
    public string Raca { get; set; } = string.Empty;

    [Required]
    [Column("ST_PCD", TypeName = "CHAR(1)")]
    public bool StPcd { get; set; }

    [MaxLength(100)]
    [Column("TIPO_PCD")]
    public string TipoPcd { get; set; } = string.Empty;

    [Required]
    [MaxLength(16)]
    [Column("NR_CPF")]
    public string Cpf { get; set; } = string.Empty;
    public string CargaHoraria { get; set; } = string.Empty;
    public string DescricaoCargaHoraria { get; set; } = string.Empty;

    [Required]
    [Column("SAL_BASE", TypeName = "NUMBER(10,2)")]
    public decimal Salario { get; set; }

    [Required]
    [Column("T_DEPTO_ID_DEPTO")]
    public int DepartamentoId { get; set; }


    [Column("MENTOR_ID")]
    public int? MentorId { get; set; }

    [ForeignKey("MentorId")]
    [InverseProperty("Mentorados")]
    public FuncionarioModel? Mentor { get; set; }

    [InverseProperty("Mentor")]
    public List<FuncionarioModel> Mentorados { get; set; } = new List<FuncionarioModel>();

    [ForeignKey("DepartamentoId")]
    public DepartamentoModel Departamento { get; set; } = new DepartamentoModel();

    [InverseProperty("Funcionario")]
    public List<DesenvolvimentoModel> Desenvolvimentos { get; set; } = new List<DesenvolvimentoModel>();
}
