using JogoJusto.AppDta;
using JogoJusto.Models;

namespace JogoJusto.Service;

public class DesenvolvimentoService : IDesenvolvimentoService
{
    private readonly JogoJustoDbContext _jogodbcontext;
    public DesenvolvimentoService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }
    public void AtualizarDesenvolvimento(object desenvolvimento)
    {
        var desenvolvimentoExistente = _jogodbcontext.Desenvolvimento.Find(((dynamic)desenvolvimento).IdDesenvolvimento);
    }

    public void CriarDesenvolvimento(object desenvolvimento)
    {
        var novoDesenvolvimento = (dynamic)desenvolvimento;
        _jogodbcontext.Desenvolvimento.Add(novoDesenvolvimento);
        _jogodbcontext.SaveChanges();

    }

    public void DeletarDesenvolvimento(int id)
    {
        var desenvolvimentoExistente = _jogodbcontext.Desenvolvimento.Find(id);

    }

    public object GetDesenvolvimentoPorId(int id)
    {
        var desenvolvimento = _jogodbcontext.Desenvolvimento.Find(id);
        return desenvolvimento ?? new DesenvolvimentoModel();
    }

    public object GetDesenvolvimentos()
    {
        var desenvolvimentos = _jogodbcontext.Desenvolvimento.ToList();
        return desenvolvimentos;
    }
}
