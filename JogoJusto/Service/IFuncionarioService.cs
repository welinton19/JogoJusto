namespace JogoJusto.Service;

public interface IFuncionarioService
{
    void CriarFuncionario(object funcionario);
    object GetFuncionarios();
    object GetFuncionarioPorId(int id);
    void AtualizarFuncionario(object funcionario);
    
    void DetallaFuncionario(int id);
}
