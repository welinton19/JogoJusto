using JogoJusto.ViewModel;

namespace JogoJusto.Service;

public interface IDepartamentoService
{
    void CriarDepartamento(string nome);
    void GestarDepartamento(int nome);
    IEnumerable<DepartamentoViewModel> GetDepartamentos();
}


