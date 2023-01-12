using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lesson35MVC.Data;

public class NewDbContext : DbContext
{
    // public DbSet<Department> Department { get; set; }
    // public DbSet<DetailsInfo> DetailsInfo { get; set; }
    // public DbSet<User> Users { get; set; }

    public NewDbContext(DbContextOptions<NewDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().Property(d => d.Foundation)
            .HasConversion<DateOnlyConverter>();
        modelBuilder.Entity<User>()
            .HasOne(user => user.Details)
            .WithOne(detailsInfo => detailsInfo.User)
            .HasForeignKey<DetailsInfo>(detailsInfo => detailsInfo.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasOne(user => user.Department)
            .WithMany(department => department.Users)
            .HasForeignKey(user => user.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    {
    }
}