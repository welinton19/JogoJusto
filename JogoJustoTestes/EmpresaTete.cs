namespace JogoJustoTestes;

public class EmpresaTete
{
    [Fact]
    public void CriandoEmpresa()
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
        //act
        var nomeEmpresa = empresa.Nome;
        //assert
        Assert.Equal("Empresa Teste", nomeEmpresa);

    }

    [Fact]
    public void AtualizandoEmpresa()
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
        //act
        empresa.Nome = "Empresa Atualizada";
        //assert
        Assert.Equal("Empresa Atualizada", empresa.Nome);
    }

    [Fact]
    public void DeletandoEmpresa()
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
        //act
        empresa = null;
        //assert
        Assert.Null(empresa);
    }

    [Fact]
    public async Task Get_ReturnOk()
    {
        // Arrange
        var empresa = new JogoJusto.Models.EmpresaModel
        {
            EmpresaId = 1,
            Nome = "Empresa Teste",
            Cnpj = "12.345.678/0001-90",
            Endereco = "Rua Teste, 123",
            Telefone = "(11) 1234-5678"
        };
        // Act
        var nomeEmpresa = empresa.Nome;
        // Assert
        Assert.Equal("Empresa Teste", nomeEmpresa);
    }
}
    



