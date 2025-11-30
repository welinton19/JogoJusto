using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class FuncionarioTeste
{
    [Fact]
    public void CriandoFuncionario()
    {
        //arrange
        var funcionario = new JogoJusto.Models.FuncionarioModel
        {
            FuncionarioId = 1,
            Nome = "João Silva",
            Cargo = "Desenvolvedor",
            DepartamentoId = 1
        };
        //act
        var nomeFuncionario = funcionario.Nome;
        //assert
        Assert.Equal("João Silva", nomeFuncionario);
    }
    [Fact]
    public void AtualizandoFuncionario()
    {
        //arrange
        var funcionario = new JogoJusto.Models.FuncionarioModel
        {
            FuncionarioId = 1,
            Nome = "João Silva",
            Cargo = "Desenvolvedor",
            DepartamentoId = 1
        };
        //act
        funcionario.Cargo = "Desenvolvedor Sênior";
        //assert
        Assert.Equal("Desenvolvedor Sênior", funcionario.Cargo);
    }
    [Fact]
    public void DeletandoFuncionario()
    {
        //arrange
        var funcionario = new JogoJusto.Models.FuncionarioModel
        {
            FuncionarioId = 1,
            Nome = "João Silva",
            Cargo = "Desenvolvedor",
            DepartamentoId = 1
        };
        //act
        funcionario = null;
        //assert
        Assert.Null(funcionario);
    }
}
