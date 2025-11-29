namespace JogoJusto.ViewModel
{
    public class FuncionarioCreateViewModel
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime? DataContratacao { get; set; }
        public string Raca { get; set; } = string.Empty;
        public bool StPcd { get; set; }
        public string? TipoPcd { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public int DepartamentoId { get; set; }
        public int? MentorId { get; set; }
    }
}
