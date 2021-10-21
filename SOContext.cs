using Microsoft.EntityFrameworkCore;

namespace EFCore6Demos
{
  public class SOContext : DbContext
  {
    public SOContext(DbContextOptions<SOContext> options)
            : base(options)
    {
    }

    public DbSet<UserReputation> UserReps { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //via scaffolding from database
      modelBuilder.Entity<UserReputation>(entity =>
      {
        entity.HasNoKey();
        entity.ToView("Reputation");
        entity.Property(e => e.Displayname)
                  .IsRequired()
                  .HasMaxLength(40)
                  .HasColumnName("displayname");
        entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasColumnName("id");
        entity.Property(e => e.Reputation).HasColumnName("reputation");
      });

    }


  }
}
