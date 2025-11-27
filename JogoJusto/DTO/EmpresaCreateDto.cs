using JogoJusto.Models;
using System.ComponentModel.DataAnnotations;

namespace JogoJusto.DTO;

public class EmpresaCreateDto
{
    public string InscricaoEstadual { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;

    public string Endereco { get; set; } = string.Empty;
    [Phone]
    public string Telefone { get; set; } = string.Empty;

    public List<DepartamentoModel> Departamentos { get; set; } = new List<DepartamentoModel>();
    public List<MetaEsgModel> MetasEsg { get; set; } = new List<MetaEsgModel>();
}
