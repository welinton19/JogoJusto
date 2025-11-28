using JogoJusto.Models;

namespace JogoJusto.AppDta.Repository;

public interface IEmpresaRepository
{
    void CriarEmpresa(EmpresaModel empresa);
    void AtualizarEmpresa(EmpresaModel empresa);
    void GetEmpresas();
    EmpresaModel GetEmpresaPorId(int id);
    void DeletarEmpresa(int id);
}
