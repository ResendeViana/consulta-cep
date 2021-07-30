using System;
using System.Collections.Generic;
using System.Text;
using validacao_cep_raro.Application.Results;
using validacao_cep_raro.Domain.Entities;
using validacao_cep_raro.Domain.ValueObjects;

namespace validacao_cep_raro.Application.Interfaces
{
    public interface IEnderecoApplication
    {
        Result<Endereco> Obter(string cepInput);
    }
}
