using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson30;

internal class NewDbContext : DbContext
{
    protected string ConnectionString =
        "Server=localhost;Integrated Security=True;Database=newdb;" +
        "TrustServerCertificate=True";

    protected string ConnectionStringFromCode =
        new SqlConnectionStringBuilder
        {
            DataSource = "127.0.0.1", InitialCatalog = "newdb",
            UserID = "sa", Password = "sa/ics5603", TrustServerCertificate = true
        }.ConnectionString;

    public DbSet<Department> Department { get; set; }
    public DbSet<DetailsInfo> DetailsInfo { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<BookAuthor> BookAuthor { get; set; }

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

        modelBuilder.Entity<Book>()
            .HasMany(book => book.Authors)
            .WithMany(author => author.Books)
            .UsingEntity<BookAuthor>(
                entityTypeBuilder => entityTypeBuilder
                    .HasOne(bookAuthor => bookAuthor.Author)
                    .WithMany()
                    .HasForeignKey(bookAuthor => bookAuthor.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict),
                entityTypeBuilder => entityTypeBuilder
                    .HasOne(bookAuthor => bookAuthor.Book)
                    .WithMany()
                    .HasForeignKey(bookAuthor => bookAuthor.BookId)
                    .OnDelete(DeleteBehavior.Restrict),
                entityTypeBuilder => entityTypeBuilder
                    .HasKey(bookAuthor => new {bookAuthor.BookId, bookAuthor.AuthorId})
            );
    }
}