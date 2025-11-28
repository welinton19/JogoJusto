namespace JogoJusto.AppDta.Repository;

public interface IEsgLogRepository
{
    void CriarEsLog(object esgLog);
    void GetEsLogs();
    void DeleteEsLogs();
}
