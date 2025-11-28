using JogoJusto.AppDta;

namespace JogoJusto.Service;

public class FuncionarioService : IFuncionarioService
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public FuncionarioService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void AtualizarFuncionario(object funcionario)
    {
        var func = funcionario as Models.FuncionarioModel;
        if (func != null)
        {
            {   
                var funcionarioExistente = _jogodbcontext.Funcionario.Find(func.FuncionarioId);
                if (funcionarioExistente != null)
                {
                    funcionarioExistente.Nome = func.Nome;
                    funcionarioExistente.DataNascimento = func.DataNascimento;
                    funcionarioExistente.Genero = func.Genero;
                    funcionarioExistente.Cargo = func.Cargo;
                    funcionarioExistente.DataContratacao = func.DataContratacao;
                    funcionarioExistente.Raca = func.Raca;
                    funcionarioExistente.StPcd = func.StPcd;
                    funcionarioExistente.TipoPcd = func.TipoPcd;
                    funcionarioExistente.Cpf = func.Cpf;
                    funcionarioExistente.CargaHoraria = func.CargaHoraria;
                    funcionarioExistente.DescricaoCargaHoraria = func.DescricaoCargaHoraria;
                    funcionarioExistente.Salario = func.Salario;
                    
                    _jogodbcontext.SaveChanges();
                }
            }
        }
    }

    public void CriarFuncionario(object funcionario)
    {
        var func = funcionario as Models.FuncionarioModel;
    }

    public void DeletarFuncionario(int id)
    {
        var funcionario = _jogodbcontext.Funcionario.Find(id);
    }

    public object GetFuncionarioPorId(int id)
    {
        var funcionario = _jogodbcontext.Funcionario.Find(id);
        return funcionario;
    }

    public object GetFuncionarios()
    {
        var funcionarios = _jogodbcontext.Funcionario.ToList();
        foreach (var func in funcionarios) 
        {
            func.Mentor = null;
            func.Mentorados = null;
            func.Departamento = null;
            func.Desenvolvimentos = null;
        }
        return funcionarios;
    }
}
