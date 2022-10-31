namespace Organizer.Models.DTOs.Board;

public class CreateBoardDTO
{
    public string Name { get; set; } = String.Empty;
    public int UserId { get; set; }
}