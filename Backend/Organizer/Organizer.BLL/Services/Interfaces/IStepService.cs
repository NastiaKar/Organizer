using Organizer.Models.DTOs.Step;

namespace Organizer.BLL.Services.Interfaces;

public interface IStepService
{
    Task<IEnumerable<DisplayStepDTO>> GetAll();
    Task<DisplayStepDTO> GetOne(int id);
    Task<DisplayStepDTO> Create(CreateStepDTO request);
    Task<DisplayStepDTO> Update(CreateStepDTO request);
    Task Delete(int id);
}