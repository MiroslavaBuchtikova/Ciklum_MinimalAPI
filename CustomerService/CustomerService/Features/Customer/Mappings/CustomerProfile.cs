using AutoMapper;

namespace CustomerService.Features.Customer.Mappings;

public class Customer : Profile
{
    public Customer()
    {
        CreateMap<DTOs.CustomerDto, Core.Entities.CustomerEntity>();
        CreateMap<Core.Entities.CustomerEntity, DTOs.CustomerDto>();
        
        CreateMap<DTOs.v2.CustomerDto, Core.Entities.CustomerEntity>();
        CreateMap<Core.Entities.CustomerEntity, DTOs.v2.CustomerDto>();
    }
}