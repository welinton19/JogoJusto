namespace JogoJusto.ViewModel
{
    public class MetaEsgCreateViewModel
    {
        public string? TipoMetaEsg { get; set; }
        public string? DescricaoMetaEsg { get; set; }
        public decimal ValorReferenciaMetaEsg { get; set; }
        public decimal ValorAtualMetaEsg { get; set; }
        public DateTime PrazoMetaEsg { get; set; }
        public int? EmpresaId { get; set; }
    }
}
