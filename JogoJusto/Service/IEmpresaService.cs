namespace JogoJusto.Service;

public interface IEmpresaService
{
    void CriarEmpresa(string nome);
    void AtualizarEmpresa(int id, string nome);
    object Get(int id);
    object Get(string nome);
    void DeletarEmpresa(int id);

}
