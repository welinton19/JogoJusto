using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class DepartamentoTeste
{
    [Fact]
    public void CriandoDepartamento()
    {
        //arrange
        var departamento = new JogoJusto.Models.DepartamentoModel
        {
            IdDepartamento = 1,
            NomeDepartamento = "Recursos Humanos",
            EmpresaId = 1
        };
        //act
        var nomeDepartamento = departamento.NomeDepartamento;
        //assert
        Assert.Equal("Recursos Humanos", nomeDepartamento);
    }

    [Fact]
    public async Task AtualizandoDepartamento()
    {
        //arrange
        var departamento = new JogoJusto.Models.DepartamentoModel
        {
            IdDepartamento = 1,
            NomeDepartamento = "Recursos Humanos",
            EmpresaId = 1
        };
        //act
        departamento.NomeDepartamento = "Financeiro";
        //assert
        Assert.Equal("Financeiro", departamento.NomeDepartamento);
    }

    [Fact]
    public void DeletandoDepartamento()
    {
        //arrange
        var departamento = new JogoJusto.Models.DepartamentoModel
        {
            IdDepartamento = 1,
            NomeDepartamento = "Recursos Humanos",
            EmpresaId = 1
        };
        //act
        departamento = null;
        //assert
        Assert.Null(departamento);
    }

    [Fact]
    public void DepartamentoEmpresaRelacionamento()
    {
        //arrange
        var empresa = new JogoJusto.Models.EmpresaModel
        {
            EmpresaId = 1,
            Nome = "Empresa Teste",
            Cnpj = "12.345.678/0001-90",
            Endereco = "Rua Teste, 123",
            Telefone = "(11) 1234-5678"
        };
        var departamento = new JogoJusto.Models.DepartamentoModel
        {
            IdDepartamento = 1,
            NomeDepartamento = "Recursos Humanos",
            EmpresaId = empresa.EmpresaId,
            Empresa = empresa
        };
        //act
        var departamentoEmpresaNome = departamento.Empresa.Nome;
        //assert
        Assert.Equal("Empresa Teste", departamentoEmpresaNome);
    }
}
