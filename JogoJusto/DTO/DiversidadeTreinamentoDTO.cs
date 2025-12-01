namespace JogoJusto.DTO
{
    public class TreinamentoDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string AreaFoco { get; set; } = string.Empty;
        public string Prioridade { get; set; } = "Média";
        public List<string> DepartamentosAfetados { get; set; } = new();
        public string Motivo { get; set; } = string.Empty;
    }

    public class TreinamentosResponseDTO
    {
        public List<TreinamentoDTO> Treinamentos { get; set; } = new();
    }
}
