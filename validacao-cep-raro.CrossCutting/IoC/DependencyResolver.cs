
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using validacao_cep_raro.Application.Applications;
using validacao_cep_raro.Application.Interfaces;
using validacao_cep_raro.Domain.Base.Config;
using validacao_cep_raro.Domain.Repositories;
using validacao_cep_raro.Infrastructure.Repositories;

namespace validacao_cep_raro.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IEnderecoApplication, EnderecoApplication>();
            services.AddScoped<IConfig, Config>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }
    }
}
