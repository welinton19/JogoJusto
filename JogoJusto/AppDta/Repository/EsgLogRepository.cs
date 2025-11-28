namespace JogoJusto.AppDta.Repository;

public class EsgLogRepository : IEsgLogRepository
{

    private readonly JogoJustoDbContext _jogodbcontext;

    public EsgLogRepository(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void CriarEsLog(object esgLog)
    {
        _jogodbcontext.EsgLogModel.Add((Models.EsgLogModel)esgLog);
        _jogodbcontext.SaveChanges();
    }

    public void DeleteEsLogs()
    {
        _jogodbcontext.EsgLogModel.RemoveRange(_jogodbcontext.EsgLogModel);
    }

    public void GetEsLogs()
    {
        _jogodbcontext.EsgLogModel.ToList();

    }
}
