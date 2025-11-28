namespace JogoJusto.Service;

public interface IDesenvolvimentoService
{
    void CriarDesenvolvimento(object desenvolvimento);
    void AtualizarDesenvolvimento(object desenvolvimento);
    object GetDesenvolvimentos();
    object GetDesenvolvimentoPorId(int id);
    void DeletarDesenvolvimento(int id);
}
