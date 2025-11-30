using JogoJusto.Models;
using JogoJusto.ViewModel;

namespace JogoJusto.Profile;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Models.UsuarioModel, ViewModel.UsuarioViewModel>().ReverseMap();

        CreateMap<Models.MetaEsgModel, ViewModel.MetaEsgViewModel>().ReverseMap();

        CreateMap<Models.DesenvolvimentoModel, ViewModel.DesenvolvimentoViewModel>().ReverseMap();

        CreateMap<Models.EsgLogModel, ViewModel.EsgLogViewModel>().ReverseMap();

        CreateMap<Models.TokenModel, ViewModel.TokenViewModel>().ReverseMap();

        CreateMap<FuncionarioModel, FuncionarioViewModel>().ReverseMap();
        CreateMap<FuncionarioCreateViewModel, FuncionarioModel>();
        CreateMap<FuncionarioUpdateViewModel, FuncionarioModel>()
           .ForAllMembers(opts =>
           {
               opts.Condition((src, dest, srcMember) =>
               {
                   if (srcMember is string s && string.IsNullOrWhiteSpace(s))
                       return false;

                   return srcMember != null;
               });
           });

        CreateMap<EmpresaModel, EmpresaViewModel>();
        CreateMap<EmpresaCreateViewModel, EmpresaModel>();
        CreateMap<EmpresaUpdateViewModel, EmpresaModel>()
            .ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is string s && string.IsNullOrWhiteSpace(s))
                        return false;

                    return srcMember != null;
                });
            });
            
        CreateMap<DepartamentoModel, DepartamentoViewModel>();
        CreateMap<DepartamentoUpdateViewModel, DepartamentoModel>()
           .ForAllMembers(opts =>
           {
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is string s && string.IsNullOrWhiteSpace(s))
                       return false;

                    return srcMember != null;
                });
           });






    }










}
