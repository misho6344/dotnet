using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace Project.Infrastructure;

public class PhysicalPersonsDbContext : DbContext
{
    public PhysicalPersonsDbContext(DbContextOptions<PhysicalPersonsDbContext> options) : base(options)
    {
    }
    public DbSet<PhysicalPerson> PhysicalPersons { get; set; }
    public DbSet<City> City { get; set; }
}