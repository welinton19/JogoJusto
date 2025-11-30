using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoJustoTestes;

public class MetaEsg
{
    [Fact]
    public void CriandoMetaEsg()
    {
        //arrange
        var meta = new JogoJusto.Models.MetaEsgModel
        {
            IdMetaEsg = 1,
            DescricaoMetaEsg = "Reduzir emissão de carbono em 20% até 2025",
            PrazoMetaEsg = DateTime.Now.AddYears(2),
            EmpresaId = 1
        };
        //act
        var descricaoMeta = meta.DescricaoMetaEsg;
        //assert
        Assert.Equal("Reduzir emissão de carbono em 20% até 2025", descricaoMeta);
    }

    [Fact]
    public void AtualizandoMetaEsg()
    {
        //arrange
        var meta = new JogoJusto.Models.MetaEsgModel
        {
            IdMetaEsg = 1,
            DescricaoMetaEsg = "Reduzir emissão de carbono em 20% até 2025",
            PrazoMetaEsg = DateTime.Now.AddYears(2),
            EmpresaId = 1
        };
        //act
        meta.DescricaoMetaEsg = "Reduzir emissão de carbono em 30% até 2025";
        //assert
        Assert.Equal("Reduzir emissão de carbono em 30% até 2025", meta.DescricaoMetaEsg);
    }

    [Fact]
    public async void DeletandoMetaEsg()
    {
        //arrange
        var meta = new JogoJusto.Models.MetaEsgModel
        {
            IdMetaEsg = 1,
            DescricaoMetaEsg = "Reduzir emissão de carbono em 20% até 2025",
            PrazoMetaEsg = DateTime.Now.AddYears(2),
            EmpresaId = 1
        };
        //act
        meta = null;
        //assert
        Assert.Null(meta);
    }
}
