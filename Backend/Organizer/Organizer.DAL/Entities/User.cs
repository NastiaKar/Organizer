using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using Organizer.DAL.Entities.Base;

namespace Organizer.DAL.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public string Salt { get; set; } = String.Empty;
    public List<Board> Boards { get; set; } = null!;
}