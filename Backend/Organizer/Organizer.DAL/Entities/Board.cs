using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using Organizer.DAL.Entities.Base;

namespace Organizer.DAL.Entities;

public class Board : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public List<Assignment> Assignments { get; set; } = null!;
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}