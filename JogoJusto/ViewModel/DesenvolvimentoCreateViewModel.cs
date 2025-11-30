namespace JogoJusto.ViewModel
{
    public class DesenvolvimentoCreateViewModel
    {
        public string TipoRegistro { get; set; } = string.Empty;
        public string DescricaoRegistro { get; set; } = string.Empty;
        public string NomeTreinamento { get; set; } = string.Empty;
        public string Treinamento { get; set; } = string.Empty;
        public DateTime? DataConclusao { get; set; }
        public decimal? DuracaoHoras { get; set; }
        public string StatusRegistro { get; set; } = "Ativo";
        public int FuncionarioId { get; set; }
    }
}
