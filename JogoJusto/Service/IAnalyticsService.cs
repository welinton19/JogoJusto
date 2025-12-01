using JogoJusto.DTO;

namespace JogoJusto.Service
{
    public interface IAnalyticsService
    {
        Task<DashboardDTO> GerarDashboardInteligenteAsync();
    }
}
