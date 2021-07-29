using AutoMapper;
using validacao_cep_raro.Domain.Entities;
using validacao_cep_raro.Domain.ValueObjects;
using validacao_cep_raro.Infrastructure.Model;

namespace validacao_cep_raro.Infrastructure.Mapper
{
    public class EnderecoMap : Profile
    {
        public EnderecoMap()
        {
            CreateMap<EnderecoApiModel, Endereco>()
                .ForMember(dest => dest.Bairro, m => m.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Complemento, m => m.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.Ddd, m => m.MapFrom(src => src.Ddd))
                .ForMember(dest => dest.Gia, m => m.MapFrom(src => src.Gia))
                .ForMember(dest => dest.Ibge, m => m.MapFrom(src => src.Ibge))
                .ForMember(dest => dest.Localidade, m => m.MapFrom(src => src.Localidade))
                .ForMember(dest => dest.Logradouro, m => m.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Siafi, m => m.MapFrom(src => src.Siafi))
                .ForMember(dest => dest.Uf, m => m.MapFrom(src => src.Uf))
                .ConstructUsing(src =>
                      new Endereco(src.Cep));
        }
    }
}
