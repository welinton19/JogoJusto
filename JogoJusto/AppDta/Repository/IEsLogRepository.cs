namespace JogoJusto.AppDta.Repository;

public interface IEsLogRepository
{
    void CriarEsLog(object esgLog);
    void GetEsLogs();
    void DeleteEsLogs();
}
