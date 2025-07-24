using System;
using System.Collections.Generic;
using Inventory_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_WebAPI.Context;

public partial class InventoryDbContext : DbContext
{
    public InventoryDbContext()
    {
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Sparepart> Spareparts { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=InventoryDB;Username=postgres;Password=Post123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpId).HasName("Expense_pkey");

            entity.ToTable("Expense");

            entity.Property(e => e.ExpId)
                .ValueGeneratedNever()
                .HasColumnName("exp_id");
            entity.Property(e => e.ExpName)
                .HasColumnType("character varying")
                .HasColumnName("exp_name");
            entity.Property(e => e.ExpType)
                .HasColumnType("character varying")
                .HasColumnName("exp_type");
            entity.Property(e => e.ExpValue)
                .HasColumnType("character varying")
                .HasColumnName("exp_value");
        });

        modelBuilder.Entity<Sparepart>(entity =>
        {
            entity.HasKey(e => e.SpId).HasName("sparepart_pk");

            entity.ToTable("Sparepart");

            entity.Property(e => e.SpId).HasColumnName("sp_id");
            entity.Property(e => e.SpAddress)
                .HasColumnType("character varying")
                .HasColumnName("sp_address");
            entity.Property(e => e.SpName)
                .HasColumnType("character varying")
                .HasColumnName("sp_name");
            entity.Property(e => e.SpPrice).HasColumnName("sp_price");
            entity.Property(e => e.SpQuantity).HasColumnName("sp_quantity");
            entity.Property(e => e.SpVendorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("sp_vendor_id");

            entity.HasOne(d => d.SpVendor).WithMany(p => p.Spareparts)
                .HasForeignKey(d => d.SpVendorId)
                .HasConstraintName("vendor_fk");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VId).HasName("vendor_pk");

            entity.ToTable("Vendor");

            entity.Property(e => e.VId).HasColumnName("v_id");
            entity.Property(e => e.VAddress)
                .HasColumnType("character varying")
                .HasColumnName("v_address");
            entity.Property(e => e.VName)
                .HasColumnType("character varying")
                .HasColumnName("v_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
