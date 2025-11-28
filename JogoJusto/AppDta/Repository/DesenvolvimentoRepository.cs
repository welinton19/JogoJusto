using JogoJusto.Models;
using Microsoft.AspNetCore.Mvc;

namespace JogoJusto.AppDta.Repository;

public class DesenvolvimentoRepository : IDesenvolvimentoRepository
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public DesenvolvimentoRepository(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void AtualizarDesenvolvimento(DesenvolvimentoModel desenvolvimento)
    {
        _jogodbcontext.Desenvolvimento.Update(desenvolvimento);
        _jogodbcontext.SaveChanges();

    }

    public void CriarDesenvolvimento(DesenvolvimentoModel desenvolvimento)
    {
        _jogodbcontext.Desenvolvimento.Add(desenvolvimento);
        _jogodbcontext.SaveChanges();

    }

    public void DeletarDesenvolvimento(int id)
    {
        var desenvolvimento = _jogodbcontext.Desenvolvimento.Find(id);
        if (desenvolvimento != null)
        {
            _jogodbcontext.Desenvolvimento.Remove(desenvolvimento);
            _jogodbcontext.SaveChanges();
        }
    }

    public DesenvolvimentoModel? GetDesenvolvimentoPorId(int id)
    {
        return _jogodbcontext.Desenvolvimento.Find(id);
    }

    public IEnumerable<DesenvolvimentoModel> GetDesenvolvimentos()
    {
        return _jogodbcontext.Desenvolvimento.ToList();
    }
}
