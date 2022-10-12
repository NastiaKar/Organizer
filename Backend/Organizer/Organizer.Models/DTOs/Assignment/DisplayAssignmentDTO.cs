using Organizer.Models.DTOs.Board;
using Organizer.Models.DTOs.Step;

namespace Organizer.Models.DTOs.Assignment;

public class DisplayAssignmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartTime { get; set; }
    public DateTime Deadline { get; set; }
    public List<DisplayStepDTO> Steps { get; set; } = null!;
    public State State { get; set; }
    public int BoardId { get; set; }
    public DisplayBoardDTO Board { get; set; } = null!;
    public bool IsCompleted { get; set; }
}