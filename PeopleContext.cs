using System;
using Microsoft.EntityFrameworkCore;

public class PeopleContext : DbContext
{
  public DbSet<Person> People { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    _ = optionsBuilder
    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
    .UseSqlServer("Server=localhost;Database=TemporalTest;Trusted_Connection=True");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Person>().ToTable(tb => tb.IsTemporal());
  }
}