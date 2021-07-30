using System;
using System.Collections.Generic;
using System.Text;
using validacao_cep_raro.Infrastructure.Model.Base;

namespace validacao_cep_raro.Infrastructure.Model
{
    public class EnderecoApiModel : ApiResponse
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public Byte Ddd { get; set; }
        public int Siafi { get; set; }
    }
}
