using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer.DAL.Entities;

public class Board
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<Assignment> Assignments { get; set; } = null!;
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    public int UserId { get; set; }
}