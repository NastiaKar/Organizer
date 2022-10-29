using Organizer.Models.DTOs.Assignment;

namespace Organizer.BLL.Services.Interfaces;

public interface IAssignmentService
{
    Task<IEnumerable<DisplayAssignmentDTO>> GetAll();
    Task<DisplayAssignmentDTO> GetOne(int id);
    Task<DisplayAssignmentDTO> Create(CreateAssignmentDTO request);
    Task<DisplayAssignmentDTO> Update(CreateAssignmentDTO request, int id);
    Task Delete(int id);
}