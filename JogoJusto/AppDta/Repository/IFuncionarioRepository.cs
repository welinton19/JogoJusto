using JogoJusto.Models;
using Newtonsoft.Json.Bson;

namespace JogoJusto.AppDta.Repository;

public interface IFuncionarioRepository
{
    void CriarFuncionario(FuncionarioModel funcionario);
    void AtualizarFuncionario(FuncionarioModel funcionario);
    void GetFuncionarios();
    FuncionarioModel GetFuncionarioPorId(int id);
    void DeletarFuncionario(int id);
}
