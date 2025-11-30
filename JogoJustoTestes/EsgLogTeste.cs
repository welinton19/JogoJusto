using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class EsgLogTeste
{
    [Fact]
    public void CriandoEsgLog()
    {
        //arrange
        var esgLog = new JogoJusto.Models.EsgLogModel
        {
            IdEsgLog = 1,
            AcaoRealizada = "Atualização de Meta ESG",
            DataAcao = DateTime.Now,
            DepartamentoId = 1
        };
        //act
        var acaoEsg = esgLog.AcaoRealizada;
        //assert
        Assert.Equal("Atualização de Meta ESG", acaoEsg);
    }
    [Fact]
    public void AtualizandoEsgLog()
    {
        //arrange
        var esgLog = new JogoJusto.Models.EsgLogModel
        {
            IdEsgLog = 1,
            AcaoRealizada = "Atualização de Meta ESG",
            DataAcao = DateTime.Now,
            DepartamentoId = 1
        };
        //act
        esgLog.AcaoRealizada = "Criação de Nova Meta ESG";
        //assert
        Assert.Equal("Criação de Nova Meta ESG", esgLog.AcaoRealizada);
    }
    [Fact]
    public void DeletandoEsgLog()
    {
        //arrange
        var esgLog = new JogoJusto.Models.EsgLogModel
        {
            IdEsgLog = 1,
            AcaoRealizada = "Atualização de Meta ESG",
            DataAcao = DateTime.Now,
            DepartamentoId = 1
        };
        //act
        esgLog = null;
        //assert
        Assert.Null(esgLog);
    }
}
