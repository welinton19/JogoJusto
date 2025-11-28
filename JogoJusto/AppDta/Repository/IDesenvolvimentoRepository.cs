namespace JogoJusto.AppDta.Repository;

public interface IDesenvolvimentoRepository
{
    void CriarDesenvolvimento(Models.DesenvolvimentoModel desenvolvimento);

    void AtualizarDesenvolvimento(Models.DesenvolvimentoModel desenvolvimento);

    Models.DesenvolvimentoModel? GetDesenvolvimentoPorId(int id);

    IEnumerable<Models.DesenvolvimentoModel> GetDesenvolvimentos();
    void DeletarDesenvolvimento(int id);
}
