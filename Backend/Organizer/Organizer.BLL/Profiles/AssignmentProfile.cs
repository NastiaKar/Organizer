using AutoMapper;
using Organizer.BLL.Extensions;
using Organizer.DAL.Entities;
using Organizer.Models.DTOs.Assignment;
using Organizer.Models.DTOs.Step;

namespace Organizer.BLL.Profiles;

public class AssignmentProfile : Profile
{
    public AssignmentProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(config =>
            config.AddProfile(new StepProfile())));

        CreateMap<CreateAssignmentDTO, Assignment>();
        
        CreateMap<UpdateAssignmentDTO, Assignment>().ForMember(dest => dest.State,
            opt => opt.MapFrom(src => src.State.ConvertToState()));
        
        CreateMap<Assignment, DisplayAssignmentDTO>()
            .ForMember(dest => dest.Steps,
            opt => opt.MapFrom(src => mapper.Map<List<DisplayStepDTO>>(src.Steps)))
            .ForMember(dest => dest.State,
                opt => opt.MapFrom(src => src.State.ToString()));
    }
}