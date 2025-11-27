using System.ComponentModel.DataAnnotations;

namespace JogoJusto.Models;

public class MetaEsgModel
{
    [Key]
    public int IdMetaEsg { get; set; }
    public string? TipoMetaEsg { get; set; }
    public string? DescricaoMetaEsg { get; set; }
    public decimal ValorReferenciaMetaEsg { get; set; }
    public decimal ValorAtualMetaEsg { get; set; }
    public DateTime AtualizacaoDados { get; set; }
    public DateTime PrazoMetaEsg { get; set; }
    public EmpresaModel? Empresa { get; set; }
}
