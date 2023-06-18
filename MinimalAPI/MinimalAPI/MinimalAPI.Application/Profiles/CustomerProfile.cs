using AutoMapper;
using MinimalAPI.MinimalAPI.Application.DTOs;
using MinimalAPI.MinimalAPI.Core.Entities;

namespace MinimalAPI.MinimalAPI.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
    }
}