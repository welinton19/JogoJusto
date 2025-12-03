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
    [Fact]
    public async Task Usuario_Retorna_200_Ok()
    {
        //arrange
        var usuario = new JogoJusto.Models.UsuarioModel
        {
            Id = 1,
            Email = "joaosilvamedeiro@email.com",
            Password = "senha123",
        };
        //act
        var emailUsuario = usuario.Email;
        //assert
        Assert.Equal("joaosilvamedeiro@email.com", emailUsuario);
    }


}
