using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer.DAL.Entities;

public class Board
{
    public int Id { get; set; }
    public List<Assignment> Assignments { get; set; } = null!;
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}