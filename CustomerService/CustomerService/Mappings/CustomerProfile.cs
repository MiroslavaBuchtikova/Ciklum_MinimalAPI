using AutoMapper;

namespace MinimalAPI.Mappings;

public class Customer : Profile
{
    public Customer()
    {
        CreateMap<Features.Customer.DTOs.CustomerDto, Core.Entities.Customer>();
        CreateMap<Core.Entities.Customer, Features.Customer.DTOs.CustomerDto>();
    }
}