using Organizer.Models.DTOs.Assignment;

namespace Organizer.Models.DTOs.Board;

public class DisplayBoardDTO
{
    public int Id { get; set; }
    public int Name { get; set; }
    public List<DisplayAssignmentDTO> Assignments { get; set; } = null!;
}