namespace JogoJusto.ViewModel;

public class TokenViewModel
{
    internal static readonly string CollectionName = "Tokens";
    internal readonly string Role;

    public string? Id { get; set; }
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
    public string? TokenId { get; set; } = string.Empty;
    public string? TokenName { get; set; } = string.Empty;
}
