using Microsoft.EntityFrameworkCore;
using static System.Environment;

public class PeopleContext : DbContext
{
  public DbSet<Person> People { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite($"Data Source=MyDatabase.db");
  }
 
}