namespace Organizer.Models.DTOs.Assignment;

public class CreateAssignmentDTO
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartTime { get; set; }
    public DateTime Deadline { get; set; }
    public int BoardId { get; set; }
}