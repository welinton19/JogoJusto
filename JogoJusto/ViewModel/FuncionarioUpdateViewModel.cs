namespace JogoJusto.ViewModel
{
    public class FuncionarioUpdateViewModel
    {
        public int FuncionarioId { get; set; }

        public string? Nome { get; set; } = string.Empty;
        public string? Genero { get; set; } = string.Empty;
        public string? Cargo { get; set; } = string.Empty;

        public string? Raca { get; set; } = string.Empty;
        public bool? StPcd { get; set; }
        public string? TipoPcd { get; set; }

        public decimal? Salario { get; set; }

        public int? DepartamentoId { get; set; }
        public int? MentorId { get; set; }
    }

}
