using Organizer.Models.DTOs.Assignment;

namespace Organizer.Models.DTOs.Board;

public class DisplayBoardDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<DisplayAssignmentDTO> Assignments { get; set; } = new();
}