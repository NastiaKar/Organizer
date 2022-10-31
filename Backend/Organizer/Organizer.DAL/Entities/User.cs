using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace Organizer.DAL.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public string Salt { get; set; } = String.Empty;
    public List<Board> Boards { get; set; } = null!;
}