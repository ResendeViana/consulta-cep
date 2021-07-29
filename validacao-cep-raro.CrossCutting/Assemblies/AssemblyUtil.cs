using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace validacao_cep_raro.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public static class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("validacao-cep-raro.Api"),
                Assembly.Load("validacao-cep-raro.Application"),
                Assembly.Load("validacao-cep-raro.Domain"),
                Assembly.Load("validacao-cep-raro.Infrastructure"),
                Assembly.Load("validacao-cep-raro.CrossCutting")
            };
        }
    }
}
