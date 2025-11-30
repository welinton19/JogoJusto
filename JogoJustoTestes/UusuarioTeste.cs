using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class UusuarioTeste
{
    [Fact]
    public void CriandoUsuario()
    {
        //arrange
        var usuario = new JogoJusto.Models.UsuarioModel
        {
            Id = 1,
            Email = "joaosilva12@gmail.com",
            Password = "senha123",
            Tipo = "usuario_teste"

        };
        //act
        var emailUsuario = usuario.Email;
        //assert
        Assert.Equal("joaosilva12@gmail.com", emailUsuario);
    }

    
}
