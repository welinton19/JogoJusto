namespace JogoJusto.DTO;

public class InsightDTO
{
    public string Descricao { get; set; } = string.Empty;
    public InsightDetalheDTO Detalhes { get; set; } = new InsightDetalheDTO();
}

public class InsightDetalheDTO
{
    public string Departamento { get; set; } = string.Empty;
    public string Indicador { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}

public class InsightsResponseDTO
{
    public List<InsightDTO> Insights { get; set; } = new();
}
