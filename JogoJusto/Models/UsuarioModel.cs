using System.ComponentModel.DataAnnotations;

namespace JogoJusto.Models;

public class UsuarioModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    public string Tipo { get; set; } = string.Empty;
}
