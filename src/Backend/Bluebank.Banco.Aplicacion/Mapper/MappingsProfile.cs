using AutoMapper;
using Bluebank.Banco.Dominio.Entity;
using Bluebank.Banco.Aplicacion.Acounts;
using Bluebank.Banco.Aplicacion.Customers;

namespace Bluebank.Banco.Aplicacion.Mapper
{
  public class MappingsProfile : Profile
  {
    public MappingsProfile()
    {
      CreateMap<Customer, CustomerDTO>().ReverseMap();
      CreateMap<Acount, AcountDTO>().ReverseMap();

      //CreateMap<Customer, CustomerDTO>().ReverseMap()
      //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
      //    .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
      //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
      //    .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
      //    .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
      //    .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
      //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
      //    .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
      //    .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
      //    .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax)).ReverseMap();
    }
  }
}