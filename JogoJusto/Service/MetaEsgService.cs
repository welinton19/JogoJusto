using JogoJusto.AppDta;

namespace JogoJusto.Service;

public class MetaEsgService : IMetaEsgService
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public MetaEsgService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void AtualizarMetaEsg(int id, object metaEsgData)
    {
        var metaExistente = _jogodbcontext.MetaEsg.Find(id);
        if (metaExistente != null) 
        {
            var metaEsgAtualizada = (JogoJusto.Models.MetaEsgModel)metaEsgData;
            metaExistente.DescricaoMetaEsg = metaEsgAtualizada.DescricaoMetaEsg;
            metaExistente.ValorAtualMetaEsg = metaEsgAtualizada.ValorAtualMetaEsg;
            metaExistente.AtualizacaoDados = DateTime.Now;
            _jogodbcontext.SaveChanges();

        }
        else
        {
            throw new Exception("Meta ESG não encontrada.");
        }
    }

    public void CriarMetaEsg(object metaEsgData)
    {
        var novaMetaEsg = (JogoJusto.Models.MetaEsgModel)metaEsgData;
        _jogodbcontext.MetaEsg.Add(novaMetaEsg);
        _jogodbcontext.SaveChanges();

    }

    public void DeletarMetaEsg(int id)
    {
        var metaExistente = _jogodbcontext.MetaEsg.Find(id);
        if (metaExistente != null) 
        {
            _jogodbcontext.MetaEsg.Remove(metaExistente);
            _jogodbcontext.SaveChanges();
        }
        else
        {
            throw new Exception("Meta ESG não encontrada.");
        }
    }

    public void GetMeaEsg()
    {
        var metas = _jogodbcontext.MetaEsg.ToList();
        foreach (var met in metas) 
        {
            Console.WriteLine($"ID: {met.IdMetaEsg}, Tipo: {met.TipoMetaEsg}, Descrição: {met.DescricaoMetaEsg}, Valor Referência: {met.ValorReferenciaMetaEsg}, Valor Atual: {met.ValorAtualMetaEsg}, Atualização Dados: {met.AtualizacaoDados}, Prazo Meta ESG: {met.PrazoMetaEsg}");
            Console.WriteLine( met.ToString() );

        }

    }

    

    
}
