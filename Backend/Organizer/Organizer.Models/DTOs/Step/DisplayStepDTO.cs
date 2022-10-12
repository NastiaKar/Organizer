namespace Organizer.Models.DTOs.Step;

public class DisplayStepDTO
{
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public bool IsCompleted { get; set; }
    public int AssignmentId { get; set; }
}