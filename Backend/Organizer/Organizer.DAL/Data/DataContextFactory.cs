using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Organizer.DAL.Data;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        var connectionString = "Data Source=NASTIA;Initial Catalog=OrganizerDB;Integrated Security=True;MultipleActiveResultSets=True";
        optionsBuilder.UseSqlServer(connectionString);
        return new DataContext(optionsBuilder.Options);
    }
}