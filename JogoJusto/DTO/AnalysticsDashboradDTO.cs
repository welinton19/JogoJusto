namespace JogoJusto.DTO;

public class AnalyticsDashboardDTO
{
    public EmpresaResumoDTO Empresa { get; set; }
    public List<DepartamentoScoreDTO> Departamentos { get; set; } = new();
    public List<FuncionariosStatusDTO> Funcionarios { get; set; } = new();
    public EsgScoreDTO ESG { get; set; }
}
