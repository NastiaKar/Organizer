
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer.DAL.Entities;

public class Step
{
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public bool IsCompleted { get; set; }
    [ForeignKey(nameof(Assignment))]
    public int AssignmentId { get; set; }

    public Assignment Assignment { get; set; } = null!;
}