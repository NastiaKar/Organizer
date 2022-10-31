using Organizer.DAL.Entities;

namespace Organizer.DAL.Repositories.Interfaces;

public interface IUserRepo : IRepo<User>
{
    Task<User?> FindByEmailAsync(string email);
}