using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace validacao_cep_raro.Test.Fixture
{
    [CollectionDefinition("Mapper")]
    public class MapperCollection : ICollectionFixture<MapperFixture>
    {
    }
}
