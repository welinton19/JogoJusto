namespace JogoJusto.DTO;

public class TokenDto
{

    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
    public string? TokenId { get; set; } = string.Empty;
    public string? TokenName { get; set; } = string.Empty;


}
