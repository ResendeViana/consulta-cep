using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using validacao_cep_raro.Application.Interfaces;
using validacao_cep_raro.Application.Models;
using validacao_cep_raro.Domain.Entities;

namespace validacao_cep_raro.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("enderecos")]
    public class EnderecoController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoApplication _enderecoApplication;
        public EnderecoController(IEnderecoApplication enderecoApplication, IMapper mapper)
        {
            _enderecoApplication = enderecoApplication;
            _mapper = mapper;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{cep}")]
        [ProducesResponseType(typeof(EnderecoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string cep)
        {
            try
            {
                var resultado = _enderecoApplication.Obter(cep);

                if (resultado.Success)
                    return Ok(_mapper.Map<Endereco, EnderecoModel>(resultado.Object));
                else
                    return BadRequest(resultado.Notifications);
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return NotFound("CEP não encontrado");
                else
                    return BadRequest(ex.Response);
            }
        }
    }
}

