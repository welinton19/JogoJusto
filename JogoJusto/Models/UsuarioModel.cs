using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogoJusto.Models;

[Table("T_USUARIO")]
public class UsuarioModel
{
    [Key]
    [Column("ID_USUARIO")]
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    [Column("EMAIL")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(8)]
    [Column("PASSWORD")]
    public string Password { get; set; } = string.Empty;

    [Column("TIPO")]
    public string Tipo { get; set; } = string.Empty;
}
