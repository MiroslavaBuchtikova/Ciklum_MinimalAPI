using AutoMapper;

namespace CustomerService.Features.Customer.Mappings;

public class Result : Profile
{
    public Result()
    {
        CreateMap<Core.Entities.CustomerEntity, DTOs.ResultDto>()
            .ForMember(destination => destination.Id, options => options.MapFrom(customer => customer.Id));
    }
}