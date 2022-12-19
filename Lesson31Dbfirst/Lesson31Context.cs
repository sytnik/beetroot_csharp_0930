using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lesson31Dbfirst;

public partial class Lesson31Context : DbContext
{
    public Lesson31Context()
    {
    }

    public Lesson31Context(DbContextOptions<Lesson31Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DetailsInfo> DetailsInfos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Integrated Security=True;Database=lesson31;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");
        });

        modelBuilder.Entity<DetailsInfo>(entity =>
        {
            entity.HasKey(e => e.InfoId);

            entity.ToTable("DetailsInfo");

            entity.HasIndex(e => e.UserId, "IX_DetailsInfo_UserId").IsUnique();

            entity.HasOne(d => d.User).WithOne(p => p.DetailsInfo)
                .HasForeignKey<DetailsInfo>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Users_DepartmentId");

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
