using Organizer.Models.DTOs.Assignment;

namespace Organizer.BLL.Services.Interfaces;

public interface IAssignmentService
{
    Task<IEnumerable<DisplayAssignmentDTO>> GetAll();
    Task<DisplayAssignmentDTO> GetOne(int id);
    Task<DisplayAssignmentDTO> Create(CreateAssignmentDTO request);
    Task<DisplayAssignmentDTO> Update(UpdateAssignmentDTO request, int id);
    Task Delete(int id);
}