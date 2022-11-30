namespace Organizer.Models.Errors;

public class ErrorResponse
{
    public List<ErrorModel> Errors { get; set; } = new();
}