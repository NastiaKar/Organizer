using System.ComponentModel.DataAnnotations.Schema;
using Organizer.Models;

namespace Organizer.DAL.Entities;

public class Assignment
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartTime { get; set; }
    public DateTime Deadline { get; set; }
    public List<Step> Steps { get; set; } = null!;
    public State State { get; set; } = State.ToDo;
    [ForeignKey(nameof(Board))]
    public int BoardId { get; set; }
    public Board Board { get; set; } = null!;
    public bool IsCompleted { get; set; }
}