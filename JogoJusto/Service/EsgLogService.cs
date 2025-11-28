using JogoJusto.AppDta;

namespace JogoJusto.Service;

public class EsgLogService : IEsgLogService
{
    private readonly JogoJustoDbContext _jogodbcontext;

    public EsgLogService(JogoJustoDbContext jogodbcontext)
    {
        _jogodbcontext = jogodbcontext;
    }

    public void CriarEsgLog(object esgLog)
    {
        var log = esgLog as Models.EsgLogModel;
    }

    public void DeleteEsgLogs()
    {
        var esgLogs = _jogodbcontext.EsgLogModel.ToList();
    }

    public object GetEsgLogs()
    {
        var esgLogs = _jogodbcontext.EsgLogModel.ToList();
        return esgLogs;
    }
}
