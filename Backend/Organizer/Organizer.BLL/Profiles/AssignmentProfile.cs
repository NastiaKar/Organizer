using AutoMapper;
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
        
        CreateMap<UpdateAssignmentDTO, Assignment>();
        
        CreateMap<Assignment, DisplayAssignmentDTO>().ForMember(dest => dest.Steps,
            options => options.MapFrom(a => mapper.Map<List<DisplayStepDTO>>(a.Steps)));
    }
}