
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Business.Employee
{
    public class EmployeeMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            BasicTypeMappers();
            AddressMapper();
            EmployeeDTOMapper();
            //base.Configure();
        }

        private static void BasicTypeMappers()
        {
            Mapper.CreateMap<string, float>().ConvertUsing(float.Parse);
            Mapper.CreateMap<string, uint>().ConvertUsing(uint.Parse);
            Mapper.CreateMap<string, long>().ConvertUsing(long.Parse);
            Mapper.CreateMap<string, decimal>().ConvertUsing(decimal.Parse);
        }

        private static void EmployeeDTOMapper()
        {
            Mapper.CreateMap<Entities.Employees.Employee, DTO.Employees.Employee>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.AddressId, opts => opts.MapFrom(src => src.AddressId))
                .ForMember(dest => dest.Addresses, opts => opts.MapFrom(src => src.Addresses == null ? new List<DTO.Employees.Address>() : src.Addresses.Select(p => Mapper.Map<DTO.Employees.Address>(p)).ToList()))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<DTO.Employees.Employee, Entities.Employees.Employee>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.AddressId, opts => opts.MapFrom(src => src.AddressId))
                .ForMember(dest => dest.Addresses, opts => opts.Ignore())
                .IgnoreAllNonExisting();
        }

        private static void AddressMapper()
        {
            Mapper.CreateMap<Entities.Employees.Address, DTO.Employees.Address>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.AddressType, opts => opts.MapFrom(src => src.AddressType))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Country))
                .ForMember(dest => dest.HouseNumber, opts => opts.MapFrom(src => src.HouseNumber))
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.State))
                .ForMember(dest => dest.StreetName, opts => opts.MapFrom(src => src.StreetName))
                .ForMember(dest => dest.Zip, opts => opts.MapFrom(src => src.Zip))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<DTO.Employees.Address, Entities.Employees.Address>()
             .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
             .ForMember(dest => dest.AddressType, opts => opts.MapFrom(src => src.AddressType))
             .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
             .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Country))
             .ForMember(dest => dest.HouseNumber, opts => opts.MapFrom(src => src.HouseNumber))
             .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.State))
             .ForMember(dest => dest.StreetName, opts => opts.MapFrom(src => src.StreetName))
             .ForMember(dest => dest.Zip, opts => opts.MapFrom(src => src.Zip))
             .IgnoreAllNonExisting();
        }
    }

    public static class MappingExtensions
    {
        /// <summary>
        /// Ignores all non existing Mappings
        /// Reference-http://stackoverflow.com/questions/954480/automapper-ignore-the-rest/6474397#6474397
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType == sourceType && x.DestinationType == destinationType);

            foreach (var property in existingMaps.GetUnmappedPropertyNames())
                expression.ForMember(property, opt => opt.Ignore());

            return expression;
        }
    }
}
