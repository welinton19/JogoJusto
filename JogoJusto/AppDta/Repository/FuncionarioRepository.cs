using JogoJusto.Models;

namespace JogoJusto.AppDta.Repository;

public class FuncionarioRepository : IFuncionarioRepository
{

    private readonly JogoJustoDbContext _jogodbcontext;

    public FuncionarioRepository(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void AtualizarFuncionario(FuncionarioModel funcionario)
    {
        _jogodbcontext.Funcionario.Update(funcionario);
        _jogodbcontext.SaveChanges();
    }

    public void CriarFuncionario(FuncionarioModel funcionario)
    {
        _jogodbcontext.Funcionario.Add(funcionario);
        _jogodbcontext.SaveChanges();

    }

    public void DeletarFuncionario(int id)
    {
        _jogodbcontext.Funcionario.Remove(GetFuncionarioPorId(id));
    }

    public FuncionarioModel GetFuncionarioPorId(int id)
    {
        if (id < 0)
        {
            throw new ArgumentException("O id do funcionário não pode ser negativo.", nameof(id));
        }

        if (_jogodbcontext.Funcionario != null)
        {
            var funcionario = _jogodbcontext.Funcionario.FirstOrDefault(f => f.FuncionarioId == id);
            if (funcionario != null)
            {
                return funcionario;
            }
        }

        throw new Exception("Funcionário não encontrado.");
    }

    public void GetFuncionarios()
    {
        _jogodbcontext.Funcionario.ToList();

    }
}
