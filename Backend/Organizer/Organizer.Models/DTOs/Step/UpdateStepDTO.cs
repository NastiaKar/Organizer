namespace Organizer.Models.DTOs.Step;

public class UpdateStepDTO
{
    public string Description { get; set; } = String.Empty;
    public bool IsCompleted { get; set; }
}