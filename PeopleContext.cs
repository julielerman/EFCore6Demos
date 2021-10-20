using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class PeopleContext : DbContext
{
  public PeopleContext()
  {
      SavingChanges += UpdateShadowProperties;

  }

  private void UpdateShadowProperties(object sender, SavingChangesEventArgs e)
  {
   foreach (var entry in ChangeTracker.Entries()
    .Where(entry => entry.Entity is Person))
    {
        entry.Property("LastUpdated").CurrentValue = DateTime.Now;
    }
  }

  public DbSet<Person> People { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=MigrationBundleDemo.db");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Person>().Property<DateTime>("LastUpdated");

  }


}