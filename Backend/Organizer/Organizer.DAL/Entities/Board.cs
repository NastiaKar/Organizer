using System.ComponentModel.DataAnnotations.Schema;
using Organizer.DAL.Entities.Base;

namespace Organizer.DAL.Entities;

public class Board : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public List<Assignment> Assignments { get; set; } = null!;
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    public int UserId { get; set; }
}