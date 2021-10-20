//using CompiledModelDemo.TheCompiledStuff;
using System;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using EFCore6Demos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using static System.Environment;

public class PeopleContext : DbContext
{
  public DbSet<Person> People { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
     .UseSqlServer("Server=.;Database=BulkConvertersDemo,Trusted_Connection=True;");
  
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   #region efcore5 code not compiled
   #if false
    //Before EF Core 6: configure a particular type
    foreach (var entity in modelBuilder.Model.GetEntityTypes ()) 
    {
      foreach (var prop in entity.GetProperties ()
               .Where (p => p.ClrType == typeof (string)))
      {
        prop.SetColumnType ("varchar(100)");
      }
    }
     //Before EF Core 6: configure a conversion PER PROPERTY ONLY
     modelBuilder.Entity<Address>().Property(a=>a.AddressTypeEnum).HasConversion<string>();
   
    //Before EF Core 6: custom conversions FOR EACH PROPERTY were a PIA
    modelBuilder.Entity<Address>().Property(ad=>ad.StructureColor)
    .HasConversion(c=>c.ToString(),s=>Color.FromName(s));

   #endif
   #endregion

  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {

    configurationBuilder.Properties<AddressTypeEnum>().HaveConversion<string>();
    configurationBuilder.Properties<Color>().HaveConversion(typeof(ColorToStringConverter));
    //mapping not limited to entity properties:
   configurationBuilder.DefaultTypeMapping<string>().IsUnicode(false);

  }
}

public class ColorToStringConverter : ValueConverter<Color, string>
{
  public ColorToStringConverter() : base(ColorString, ColorStruct) { }

  private static Expression<Func<Color, string>> ColorString = v => new String(v.Name);
  private static Expression<Func<string, Color>> ColorStruct = v => Color.FromName(v);

}