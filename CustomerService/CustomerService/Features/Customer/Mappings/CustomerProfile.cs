using AutoMapper;

namespace CustomerService.Features.Customer.Mappings;

public class Customer : Profile
{
    public Customer()
    {
        CreateMap<DTOs.CustomerRequestDto, Core.Entities.CustomerEntity>();
        CreateMap<Core.Entities.CustomerEntity, DTOs.CustomerResponseDto>();
        
        CreateMap<DTOs.v2.CustomerRequestDto, Core.Entities.CustomerEntity>();
        CreateMap<Core.Entities.CustomerEntity, DTOs.v2.CustomerResponseDto>();
    }
}