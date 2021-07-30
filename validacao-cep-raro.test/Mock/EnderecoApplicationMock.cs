using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;
using validacao_cep_raro.Domain.Entities;
using validacao_cep_raro.Domain.Repositories;
using validacao_cep_raro.Domain.ValueObjects;

namespace validacao_cep_raro.Test.Mock
{
    public class EnderecoRepositoryMock : IEnderecoRepository
    {
        public Endereco ObterPorCep(Cep cep)
        {
            var endereco = Enderecos.FirstOrDefault(c => c.Cep == cep.ToString());

            if(endereco == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return endereco;
        }

        private static IEnumerable<Endereco> Enderecos
        {
            get
            {
                return new List<Endereco>()
                {
                    new Endereco("35353535")
                    {
                        Uf = "MG",
                        Bairro = "Bairro",
                        Complemento = "Complemento",
                        Ddd = 31,
                        Gia = "GIA",
                        Ibge = "Ibge",
                        Localidade = "Localidade",
                        Logradouro = "Logradouro",
                        Siafi = 123
                    },
                    new Endereco("01001100")
                    {
                        Uf = "SP",
                        Bairro = "Bairro",
                        Complemento = "Complemento",
                        Ddd = 11,
                        Gia = "GIA",
                        Ibge = "Ibge",
                        Localidade = "Localidade",
                        Logradouro = "Logradouro",
                        Siafi = 123
                    }
                };
            }
        }
    }
}
