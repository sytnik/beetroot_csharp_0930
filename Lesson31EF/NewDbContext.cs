using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Lesson31EF;

internal class NewDbContext : DbContext
{

    protected string ConnectionStringFromCode =
        new SqlConnectionStringBuilder
        {
            DataSource = "127.0.0.1", InitialCatalog = "lesson31",
            UserID = "sa", Password = "sa/ics5603", TrustServerCertificate = true
        }.ConnectionString;

    public DbSet<DetailsInfo> DetailsInfo { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionStringFromCode);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(user => user.Details)
            .WithOne(detailsInfo => detailsInfo.User)
            .HasForeignKey<DetailsInfo>(detailsInfo => detailsInfo.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(user => user.Department)
            .WithMany(department => department.Users)
            .HasForeignKey(user => user.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}