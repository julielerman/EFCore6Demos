using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore6Demos
{
    public  class SOContext : DbContext
  
    {
  

    public SOContext(DbContextOptions<SOContext> options)
            : base(options)
        {
        }

        public  DbSet<UserReputation> UserReps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=;Database=StackOverflow2010;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
