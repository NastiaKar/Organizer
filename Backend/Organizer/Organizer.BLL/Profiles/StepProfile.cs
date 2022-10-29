using AutoMapper;
using Organizer.DAL.Entities;
using Organizer.Models.DTOs.Step;

namespace Organizer.BLL.Profiles;

public class StepProfile : Profile
{
    public StepProfile()
    {
        CreateMap<CreateStepDTO, Step>();
        CreateMap<UpdateStepDTO, Step>();
        CreateMap<Step, DisplayStepDTO>();
    }
}