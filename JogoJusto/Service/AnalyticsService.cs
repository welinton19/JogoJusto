using JogoJusto.AppDta;
using JogoJusto.AppDta.Repository;
using JogoJusto.DTO;

namespace JogoJusto.Service;

public class AnalyticsService : IAnalyticsService
{
    private readonly JogoJustoDbContext _jogoJustoDbContext;

    public AnalyticsService(JogoJustoDbContext jogoJustoDbContext)
    {
        _jogoJustoDbContext = jogoJustoDbContext;
    }

    public AnalysticsDashboradDTO GerarDashboardInteligente()
    {
        var empresaResumo = EmpresaResumoDTO.CalcularResumo(_jogoJustoDbContext);
        return empresaResumo;
    }
}
