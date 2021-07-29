using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using validacao_cep_raro.Application.Models;
using validacao_cep_raro.Domain.Entities;

namespace validacao_cep_raro.Application.Mapper
{
    public class EnderecoMap : Profile
    {
        public EnderecoMap()
        {
               CreateMap<Endereco, EnderecoModel>()
                .ForMember(dest => dest.Bairro ,m => m.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Cep, m => m.MapFrom(src => src.Cep.ToString()))
                .ForMember(dest => dest.Complemento, m => m.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.Ddd, m => m.MapFrom(src => src.Ddd))
                .ForMember(dest => dest.Gia, m => m.MapFrom(src => src.Gia))
                .ForMember(dest => dest.Ibge, m => m.MapFrom(src => src.Ibge))
                .ForMember(dest => dest.Localidade, m => m.MapFrom(src => src.Localidade))
                .ForMember(dest => dest.Logradouro, m => m.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Siafi, m => m.MapFrom(src => src.Siafi))
                .ForMember(dest => dest.Uf, m => m.MapFrom(src => src.Uf));
        }
    }
}
