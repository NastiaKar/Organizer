using AutoMapper;
using Organizer.DAL.Entities;
using Organizer.Models.DTOs.Assignment;
using Organizer.Models.DTOs.Board;

namespace Organizer.BLL.Profiles;

public class BoardProfile : Profile
{
    public BoardProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(config =>
            config.AddProfiles(new Profile[] {new AssignmentProfile(), new StepProfile()})));

        CreateMap<CreateBoardDTO, Board>();

        CreateMap<UpdateBoardDTO, Board>();

        CreateMap<Board, DisplayBoardDTO>().ForMember(dest => dest.Assignments,
            options => options.MapFrom(b => mapper.Map<List<DisplayAssignmentDTO>>(b.Assignments)));
    }
}