using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using validacao_cep_raro.Domain.Base.Entities;
using validacao_cep_raro.Domain.ValueObjects;

namespace validacao_cep_raro.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Cep { get; private set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public Byte Ddd { get; set; }
        public int Siafi { get; set; }

        public Endereco (string cep)
        {
            Cep = cep;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Cep, nameof(Cep), "CEP não pode ser nulo"));

        }
    }
}
