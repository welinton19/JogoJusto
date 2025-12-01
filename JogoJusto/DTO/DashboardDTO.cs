namespace JogoJusto.DTO
{
    public class DashboardDTO
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int TotalFuncionarios { get; set; }
        public int TotalDepartamentos { get; set; }
        public decimal ScoreEsgMedio { get; set; }
        public EsgScoreDTO Esg { get; set; } = new();
    }
}
