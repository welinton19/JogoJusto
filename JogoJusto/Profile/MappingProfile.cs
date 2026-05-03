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
        //CreateMap<FuncionarioCreateViewModel, FuncionarioModel>();

        CreateMap<FuncionarioCreateViewModel, FuncionarioModel>()
            .ForMember(dest => dest.Cargo,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Cargo) ? "Não informado" : src.Cargo))
            .ForMember(dest => dest.Nome,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Nome) ? "Não informado" : src.Nome))
            .ForMember(dest => dest.Genero,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Genero) ? "Não informado" : src.Genero))
            .ForMember(dest => dest.Raca,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Raca) ? "Não informado" : src.Raca))
            .ForMember(dest => dest.Cpf,
                opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Cpf) ? "000.000.000-00" : src.Cpf))
            .ForMember(dest => dest.Departamento, opt => opt.Ignore())
            .ForMember(dest => dest.Mentor, opt => opt.Ignore())
            .ForMember(dest => dest.Mentorados, opt => opt.Ignore())
            .ForMember(dest => dest.Desenvolvimentos, opt => opt.Ignore());




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
