using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using validacao_cep_raro.Domain.Entities;
using validacao_cep_raro.Domain.Repositories;
using validacao_cep_raro.Domain.ValueObjects;
using validacao_cep_raro.Infrastructure.Model;

namespace validacao_cep_raro.Infrastructure.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IMapper _mapper;
        public EnderecoRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Endereco ObterPorCep(Cep cep)
        {
            var client = new RestClient("https://viacep.com.br/ws/");

            var request = new RestRequest($"{cep.ToString()}/json/", DataFormat.Json);

            var response = client.Get(request);

            if (response.IsSuccessful)
            {
                var endereco = JsonConvert.DeserializeObject<EnderecoApiModel>(response.Content);
                return _mapper.Map<EnderecoApiModel, Endereco>(endereco);
            }

            throw new NotImplementedException();

        }
    }
}
