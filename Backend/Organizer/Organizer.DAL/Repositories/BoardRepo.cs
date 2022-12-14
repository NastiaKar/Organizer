using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Base;
using Organizer.DAL.Repositories.Interfaces;

namespace Organizer.DAL.Repositories;

public class BoardRepo : BaseRepo<Board>, IBoardRepo
{
    public BoardRepo(DataContext context) : base(context) { }

    internal BoardRepo(DbContextOptions<DataContext> options) : base(options) { }

    public override async Task<IEnumerable<Board>> GetAllAsync()
    {
        return await Task.Run(() => Table
            .Include(b => b.User)
            .Include(b => b.Assignments));
    }

    public override async Task<Board?> FindAsync(int id)
    {
        return await Table
            .Where(b => b.Id == id)
            .Include(b => b.Assignments)
            .Include(b => b.User)
            .FirstOrDefaultAsync();
    }

    public override async Task<Board?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(b => b.Id == id)
            .Include(b => b.Assignments)
            .Include(b => b.User)
            .FirstOrDefaultAsync();
    }
}