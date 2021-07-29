using System;
using System.Collections.Generic;
using System.Text;
using validacao_cep_raro.Application.Interfaces;
using validacao_cep_raro.Application.Results;
using validacao_cep_raro.Domain.Entities;
using validacao_cep_raro.Domain.Repositories;
using validacao_cep_raro.Domain.ValueObjects;

namespace validacao_cep_raro.Application.Applications
{
    public class EnderecoApplication : IEnderecoApplication
    {
        private readonly IEnderecoRepository _enderecoRepositorio;

        public EnderecoApplication(IEnderecoRepository enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public Result<Endereco> Obter(string cepInput)
        {
            var cep  = new Cep(cepInput);

            if (cep.Valid)
            {
                var endereco = _enderecoRepositorio.ObterPorCep(cep);
                return Result<Endereco>.Ok(endereco);
            }

            return Result<Endereco>.Error(cep.Notifications);
        }
    }
}
