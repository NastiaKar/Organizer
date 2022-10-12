namespace Organizer.Models.DTOs.Step;

public class CreateStepDTO
{
    public string Description { get; set; } = String.Empty;
    public int AssignmentId { get; set; }
}