using AutoMapper;
using MinimalAPI.Dtos;
using MinimalAPI.Entities;

namespace MinimalAPI.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
    }
}