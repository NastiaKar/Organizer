using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Entities;

namespace Organizer.DAL.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Board> Boards { get; set; } = null!;
    public DbSet<Assignment> Assignments { get; set; } = null!;
    public DbSet<Step> Steps { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user
                .HasMany(u => u.Boards)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Board>(board =>
        {
            board
                .HasMany(b => b.Assignments)
                .WithOne(a => a.Board)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Assignment>(assignment =>
        {
            assignment
                .HasMany(a => a.Steps)
                .WithOne(s => s.Assignment)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}