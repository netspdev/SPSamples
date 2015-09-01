using AutoMapper;
using Business.Employee;

namespace Business
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new EmployeeMapperProfile()));

            Mapper.AssertConfigurationIsValid();
        }
    }
}
