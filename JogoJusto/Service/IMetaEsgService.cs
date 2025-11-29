namespace JogoJusto.Service;

public interface IMetaEsgService
{
    void CriarMetaEsg(object metaEsgData);
    void AtualizarMetaEsg(int id, object metaEsgData);
    void DeletarMetaEsg(int id);
    void GetMetaEsg();
}
