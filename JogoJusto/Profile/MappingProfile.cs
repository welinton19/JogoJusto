using JogoJusto.Models;
using JogoJusto.ViewModel;

namespace JogoJusto.Profile;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioModel, UsuarioViewModel>().ReverseMap();

        CreateMap<EsgLogModel, EsgLogViewModel>().ReverseMap();

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

        CreateMap<DesenvolvimentoModel, DesenvolvimentoViewModel>().ReverseMap();
        CreateMap<DesenvolvimentoCreateViewModel, DesenvolvimentoModel>();
        CreateMap<DesenvolvimentoUpdateViewModel, DesenvolvimentoModel>()
            .ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is string s && string.IsNullOrWhiteSpace(s))
                        return false;

                    return srcMember != null;
                });
            });

        CreateMap<MetaEsgModel, MetaEsgViewModel>().ReverseMap();
        CreateMap<MetaEsgCreateViewModel, MetaEsgModel>();
        CreateMap<MetaEsgUpdateViewModel, MetaEsgModel>()
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
