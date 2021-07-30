using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using validacao_cep_raro.Application.Mapper;

namespace validacao_cep_raro.Test.Fixture
{
    public class MapperFixture
    {
        public IMapper Mapper { get; }

        public MapperFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new EnderecoMap());
            });

            Mapper = config.CreateMapper();
        }
    }
}
