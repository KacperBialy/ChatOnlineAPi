using AutoMapper;
using ChatOnline.Application.Common.Mappings;

namespace Application.UnitTests.Mapping
{
    public class MappingTestFixture
    {
        public IConfigurationProvider ConfigurationProvider { get; set; }
        public IMapper Mapper { get; set; }

        public MappingTestFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }
    }
}
