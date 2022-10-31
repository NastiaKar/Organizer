using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Base;
using Organizer.DAL.Repositories.Interfaces;

namespace Organizer.DAL.Repositories;

public class UserRepo : BaseRepo<User>, IUserRepo
{
    public UserRepo(DataContext context) : base(context) { }
    internal UserRepo(DbContextOptions<DataContext> options) : base(options) { }

    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        return await Task.Run(() => Table
            .Include(u => u.Boards));
    }

    public override async Task<User?> FindAsync(int id)
    {
        return await Table
            .Where(u => u.Id == id)
            .Include(u => u.Boards)
            .FirstOrDefaultAsync();
    }

    public override async Task<User?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(u => u.Id == id)
            .Include(u => u.Boards)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Table
            .Where(u => u.Email == email)
            .Include(u => u.Boards)
            .FirstOrDefaultAsync();
    }
}