using JogoJusto.Models;

namespace JogoJusto.AppDta.Repository;

public interface IMetaEsgRepository
{
    void CriarMetaEsg(MetaEsgModel meta);
    MetaEsgModel? ObterMetaEsgPorId(int id);
    IEnumerable<MetaEsgModel> ObterTodasMetasEsg();
    void AtualizarMetaEsg(MetaEsgModel meta);
    void DeletarMetaEsg(int id);
}
