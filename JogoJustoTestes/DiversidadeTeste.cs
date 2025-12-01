using JogoJusto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class DiversidadeTeste
{
    [Fact]
    public void VerificarDiversidade()
    {
        //arrange
        var funcionarios = new List<(string Nome, string Genero, int Idade, string Pcd, string Raca)>
        {
            ("Ana", "Feminino", 28, "não", "Negra"),
            ("Bruno", "Masculino", 35, "sim", "Negra"),
            ("Carla", "Feminino", 42, "não", "Parda"),
            ("Daniel", "Masculino", 30,"Sim", " Branca"),
            ("Eva", "Feminino", 25, "Sim", "Negra")
        };
        //act
        var totalFuncionarios = funcionarios.Count;
        var totalFeminino = funcionarios.Count(f => f.Genero == "Feminino");
        var totalMasculino = funcionarios.Count(f => f.Genero == "Masculino");
        var porcentagemFeminino = (double)totalFeminino / totalFuncionarios * 100;
        var porcentagemMasculino = (double)totalMasculino / totalFuncionarios * 100;
        //assert
        Assert.Equal(5, totalFuncionarios);
        Assert.Equal(60, porcentagemFeminino);
        Assert.Equal(40, porcentagemMasculino);
    }

    [Fact]
    public void DiversidadeIndicadoresInvalidos()
    {
        //arrange
        var funcionarios = new List<(string Nome, string Genero, int Idade, string Pcd, string Raca)>
        {
            ("Ana", "Feminino", 28, "não", "Negra"),
            ("Bruno", "Masculino", 35, "sim", "Negra"),
            ("Carla", "Feminino", 42, "não", "Parda"),
            ("Daniel", "Masculino", 30,"Sim", " Branca"),
            ("Eva", "Feminino", 25, "Sim", "Negra")
        };
        //act
        var totalFuncionarios = funcionarios.Count;
        var totalNaoBinario = funcionarios.Count(f => f.Genero == "Não Binário");
        var porcentagemNaoBinario = (double)totalNaoBinario / totalFuncionarios * 100;
        //assert
        Assert.Equal(5, totalFuncionarios);
        Assert.Equal(0, porcentagemNaoBinario);
    }
    [Fact]
    public void VerificarDiversidadePcd()
    {
        //arrange
        var funcionarios = new List<(string Nome, string Genero, int Idade, string Pcd, string Raca)>
        {
            ("Ana", "Feminino", 28, "não", "Negra"),
            ("Bruno", "Masculino", 35, "sim", "Negra"),
            ("Carla", "Feminino", 42, "não", "Parda"),
            ("Daniel", "Masculino", 30,"Sim", " Branca"),
            ("Eva", "Feminino", 25, "Sim", "Negra")
        };
        //act
        var totalFuncionarios = funcionarios.Count;
        var totalPcd = funcionarios.Count(f => f.Pcd.ToLower() == "sim");
        var porcentagemPcd = (double)totalPcd / totalFuncionarios * 100;
        //assert
        Assert.Equal(5, totalFuncionarios);
        Assert.Equal(60, porcentagemPcd);
    }

    [Fact]
    public void DiversidadeRacaInvalida()
    {
        //arrange
        var funcionarios = new List<(string Nome, string Genero, int Idade, string Pcd, string Raca)>
        {
            ("Ana", "Feminino", 28, "não", "Negra"),
            ("Bruno", "Masculino", 35, "sim", "Negra"),
            ("Carla", "Feminino", 42, "não", "Parda"),
            ("Daniel", "Masculino", 30,"Sim", " Branca"),
            ("Eva", "Feminino", 25, "Sim", "Negra")
        };
        //act
        var totalFuncionarios = funcionarios.Count;
        var totalIndigena = funcionarios.Count(f => f.Raca == "Indígena");
        var porcentagemIndigena = (double)totalIndigena / totalFuncionarios * 100;
        //assert
        Assert.Equal(5, totalFuncionarios);
        Assert.Equal(0, porcentagemIndigena);
    }

    [Fact]
    public void DiversidadeVazia()
    {
        //arrange
        var funcionarios = new List<(string Nome, string Genero, int Idade, string Pcd, string Raca)>();
        //act
        var totalFuncionarios = funcionarios.Count;
        //assert
        Assert.Equal(0, totalFuncionarios);
    }

    [Fact]
    public void VerificarDiversidadeIdade()
    {
        //arrange
        var funcionarios = new List<(string Nome, string Genero, int Idade, string Pcd, string Raca)>
        {
            ("Ana", "Feminino", 28, "não", "Negra"),
            ("Bruno", "Masculino", 35, "sim", "Negra"),
            ("Carla", "Feminino", 42, "não", "Parda"),
            ("Daniel", "Masculino", 30,"Sim", " Branca"),
            ("Eva", "Feminino", 25, "Sim", "Negra")
        };
        //act
        var totalFuncionarios = funcionarios.Count;
        var totalMenor30 = funcionarios.Count(f => f.Idade < 30);
        var porcentagemMenor30 = (double)totalMenor30 / totalFuncionarios * 100;
        //assert
        Assert.Equal(5, totalFuncionarios);
        Assert.Equal(40, porcentagemMenor30);
    }
}
