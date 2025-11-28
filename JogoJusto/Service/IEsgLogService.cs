namespace JogoJusto.Service;

public interface IEsgLogService
{
    void CriarEsgLog(object esgLog);
    object GetEsgLogs();
    void DeleteEsgLogs();

}
