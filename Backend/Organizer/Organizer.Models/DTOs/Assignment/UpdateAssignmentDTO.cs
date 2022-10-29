namespace Organizer.Models.DTOs.Assignment;

public class UpdateAssignmentDTO
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartTime { get; set; }
    public DateTime Deadline { get; set; }
    public string State { get; set; } = String.Empty;
    public bool IsCompleted { get; set; }
}