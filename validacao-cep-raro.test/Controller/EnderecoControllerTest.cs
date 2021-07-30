using Microsoft.AspNetCore.Mvc;
using validacao_cep_raro.Application.Applications;
using validacao_cep_raro.Controllers;
using validacao_cep_raro.Test.Fixture;
using validacao_cep_raro.Test.Mock;
using Xunit;

namespace validacao_cep_raro.Test.Controller
{
    [Collection("Mapper")]
    public class EnderecoControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        private readonly EnderecoController _controller;

        public EnderecoControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
            _controller = CreateClienteController();

        }


        [Theory]
        [InlineData("35353535")]
        [InlineData("01001100")]
        public void ObterCep_Sucesso_Test(string cep)
        {
            var result = _controller.Get(cep);

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData("1234567")]
        [InlineData("010")]
        [InlineData("353535AB")]
        [InlineData("0100110C")]
        public void ObterCep_Invalido_Test(string cep)
        {
            var result = _controller.Get(cep);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData("35353538")]
        [InlineData("01001200")]
        public void ObterCep_Inexistente_Test(string cep)
        {
            var result = _controller.Get(cep);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        private EnderecoController CreateClienteController()
        {
            var enderecoApplicationMock = new EnderecoApplication(new EnderecoRepositoryMock());

            return new EnderecoController(enderecoApplicationMock, _mapperFixture.Mapper);
        }
    }
}
