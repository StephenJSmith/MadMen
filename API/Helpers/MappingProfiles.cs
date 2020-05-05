using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
        CreateMap<Job, JobToReturnDto>()
            .ForMember(d => d.JobCategory, o => o.MapFrom(s => s.JobCategory.Name))
            .ForMember(d => d.JobState, o => o.MapFrom(s => s.JobState.Name))
            .ForMember(d => d.Location, o => o.MapFrom(s => s.Location.Name))
            .ForMember(d => d.Product, o => o.MapFrom(s => s.Product.Name));
        CreateMap<Address, AddressDto>().ReverseMap();
    }
  }
}