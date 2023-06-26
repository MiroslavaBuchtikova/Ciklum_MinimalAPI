using AutoMapper;

namespace MinimalAPI.Mappings;

public class Result : Profile
{
    public Result()
    {
        CreateMap<Core.Entities.Customer, Features.Customer.DTOs.ResultDto>()
            .ForMember(destination => destination.Id, options => options.MapFrom(customer => customer.Id));
    }
}