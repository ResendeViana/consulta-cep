
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;


namespace validacao_cep_raro.Domain.Base.Config
{
    [ExcludeFromCodeCoverage]
    public class Config : IConfig
    {
        private readonly IConfiguration _configuration;

        public Config(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string UrlApiCep => _configuration["Urls:UrlApiCep"];
    }
}
