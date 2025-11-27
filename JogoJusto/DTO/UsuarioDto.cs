using System.ComponentModel.DataAnnotations;

namespace JogoJusto.DTO;

public class UsuarioDto
{
  
    
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

    public string Tipo { get; set; } = string.Empty;
}
