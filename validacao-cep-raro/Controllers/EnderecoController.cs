using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using validacao_cep_raro.Application.Interfaces;
using validacao_cep_raro.Application.Models;
using validacao_cep_raro.Domain.Entities;

namespace validacao_cep_raro.Controllers
{
    [ApiController]
    [Route("enderecos")]
    public class EnderecoController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoApplication _enderecoApplication;
        public EnderecoController(IEnderecoApplication enderecoApplication, IMapper mapper)
        {
            _enderecoApplication = enderecoApplication;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{cep}")]
        [ProducesResponseType(typeof(EnderecoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string cep)
        {
            var resultado = _enderecoApplication.Obter(cep);

            if (resultado.Success)
                return Ok(_mapper.Map<Endereco, EnderecoModel>(resultado.Object));

            return BadRequest(resultado.Notifications);
        }
    }
}
