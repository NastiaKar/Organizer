using System.ComponentModel.DataAnnotations.Schema;
using Organizer.DAL.Entities.Base;

namespace Organizer.DAL.Entities;

public class Step : BaseEntity
{
    public string Description { get; set; } = String.Empty;
    public bool IsCompleted { get; set; }
    [ForeignKey(nameof(Assignment))]
    public int AssignmentId { get; set; }

    public Assignment Assignment { get; set; } = null!;
}