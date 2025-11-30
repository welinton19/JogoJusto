using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class DesenvolvimentoTeste
{
    [Fact]
    public void CriandoDesenvolvimento()
    {
        //arrange
        var desenvolvimento = new JogoJusto.Models.DesenvolvimentoModel
        {
            IdDesenvolvimento = 1,
            TipoRegistro = "Treinamento",
            DescricaoRegistro = "Curso de C# Avançado",
            NomeTreinamento = "C# Avançado",
            Treinamento = "Udemy",
            DataConclusao = DateTime.Now,
            DuracaoHoras = 40.5m,
            DataRegistroDeDados = DateTime.Now,
            StatusRegistro = "Ativo",
            FuncionarioId = 1
        };
        //act
        var tipoRegistro = desenvolvimento.TipoRegistro;
        //assert
        Assert.Equal("Treinamento", tipoRegistro);
    }

    [Fact]
    public async Task AtualizandoDesenvolvimento()
    {
        //arrange
        var desenvolvimento = new JogoJusto.Models.DesenvolvimentoModel
        {
            IdDesenvolvimento = 1,
            TipoRegistro = "Treinamento",
            DescricaoRegistro = "Curso de C# Avançado",
            NomeTreinamento = "C# Avançado",
            Treinamento = "Udemy",
            DataConclusao = DateTime.Now,
            DuracaoHoras = 40.5m,
            DataRegistroDeDados = DateTime.Now,
            StatusRegistro = "Ativo",
            FuncionarioId = 1
        };
        //act
        desenvolvimento.StatusRegistro = "Inativo";
        //assert
        Assert.Equal("Inativo", desenvolvimento.StatusRegistro);
    }

    [Fact]
    public void DeletandoDesenvolvimento()
    {
        //arrange
        var desenvolvimento = new JogoJusto.Models.DesenvolvimentoModel
        {
            IdDesenvolvimento = 1,
            TipoRegistro = "Treinamento",
            DescricaoRegistro = "Curso de C# Avançado",
            NomeTreinamento = "C# Avançado",
            Treinamento = "Udemy",
            DataConclusao = DateTime.Now,
            DuracaoHoras = 40.5m,
            DataRegistroDeDados = DateTime.Now,
            StatusRegistro = "Ativo",
            FuncionarioId = 1
        };
        //act
        desenvolvimento = null;
        //assert
        Assert.Null(desenvolvimento);
    }
}
