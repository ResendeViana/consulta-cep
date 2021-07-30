using AutoMapper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Web.Http;
using validacao_cep_raro.Domain.Base.Config;
using validacao_cep_raro.Domain.Entities;
using validacao_cep_raro.Domain.Repositories;
using validacao_cep_raro.Domain.ValueObjects;
using validacao_cep_raro.Infrastructure.Model;

namespace validacao_cep_raro.Infrastructure.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IMapper _mapper;
        private readonly IRestClient _cliente;
        private readonly IConfig _config;
        public EnderecoRepository(IMapper mapper, IConfig config)
        {
            _mapper = mapper;
            _config = config;
            _cliente = new RestClient(_config.UrlApiCep);

        }

        public Endereco ObterPorCep(Cep cep)
        {

            var request = new RestRequest($"{cep.ToString()}/json/", DataFormat.Json);

            var response = _cliente.Get(request);

            if (response.IsSuccessful)
            {
                var endereco = JsonConvert.DeserializeObject<EnderecoApiModel>(response.Content);

                if (endereco.Erro)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return _mapper.Map<EnderecoApiModel, Endereco>(endereco);
            }

            throw new HttpResponseException(HttpStatusCode.InternalServerError);

        }
    }
}
