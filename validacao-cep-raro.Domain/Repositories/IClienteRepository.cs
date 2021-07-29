using System;
using System.Collections.Generic;
using System.Text;
using validacao_cep_raro.Domain.Entities;
using validacao_cep_raro.Domain.ValueObjects;

namespace validacao_cep_raro.Domain.Repositories
{
    public interface IEnderecoRepository
    {
        Endereco ObterPorCep(Cep cep);
    }
}
