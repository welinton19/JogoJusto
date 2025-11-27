using System.ComponentModel.DataAnnotations;

namespace JogoJusto.Models;

public class TokenModel
{
    internal static readonly string CollectionName = "Tokens";
    internal readonly string Role;

    [Key]
    public string? Id { get; set; }
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
    public string? TokenId { get; set; } = string.Empty;
    public string? TokenName { get; set; } = string.Empty;

}
