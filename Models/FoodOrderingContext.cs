using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Food_Ordering_Web.Models;

public partial class FoodOrderingContext : DbContext
{
    public FoodOrderingContext()
    {
    }

    public FoodOrderingContext(DbContextOptions<FoodOrderingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=FoodOrdering;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07869F2465");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
