using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Practice.Models;

public partial class EfPracContext : DbContext
{
    public EfPracContext()
    {
    }

    public EfPracContext(DbContextOptions<EfPracContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Courses> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Courses>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__courses__213EE774C5B9ABC8");

            entity.ToTable("courses");

            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.CDuration)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("c_duration");
            entity.Property(e => e.CFee).HasColumnName("c_fee");
            entity.Property(e => e.CName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("c_name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("PK__students__2F3684F4F3B7ABFB");

            entity.ToTable("students");

            entity.Property(e => e.SId).HasColumnName("s_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("s_address");
            entity.Property(e => e.SCaste)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("s_caste");
            entity.Property(e => e.SName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("s_name");
            entity.Property(e => e.SPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("s_phone");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__students__id__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
