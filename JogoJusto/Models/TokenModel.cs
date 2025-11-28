using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_TOKENS")]
public class TokenModel
{
    internal static readonly string CollectionName = "Tokens";
    internal readonly string Role;

    [Key]
    [Column("ID_TOKEN")]
    public string? Id { get; set; }

    [Column("TOKEN")]
    public string? Token { get; set; }

    [Column("DT_EXP")]
    public DateTime Expiration { get; set; }
    public string? TokenId { get; set; } = string.Empty;
    public string? TokenName { get; set; } = string.Empty;

}
