using AutoMapper;

namespace MinimalAPI.Application.Mappings;

public class Customer : Profile
{
    public Customer()
    {
        CreateMap<Features.Customer.DomainModels.Customer, Core.Entities.Customer>();
        CreateMap<Core.Entities.Customer, Features.Customer.DomainModels.Customer>();
    }
}