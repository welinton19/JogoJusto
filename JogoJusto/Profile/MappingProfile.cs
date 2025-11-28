namespace JogoJusto.Profile;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Models.UsuarioModel, ViewModel.UsuarioViewModel>().ReverseMap();

        CreateMap<Models.MetaEsgModel, ViewModel.MetaEsgViewModel>().ReverseMap();

        CreateMap<Models.EmpresaModel, ViewModel.EmpresaViewModel>().ReverseMap();

        CreateMap<Models.DepartamentoModel, ViewModel.DepartamentoViewModel>().ReverseMap();

        CreateMap<Models.DesenvolvimentoModel, ViewModel.DesenvolvimentoViewModel>().ReverseMap();

        CreateMap<Models.EsgLogModel, ViewModel.EsgLogViewModel>().ReverseMap();

        CreateMap<Models.FuncionarioModel, ViewModel.FuncionarioViewModel>().ReverseMap();

        CreateMap<Models.TokenModel, ViewModel.TokenViewModel>().ReverseMap();
    }


}
