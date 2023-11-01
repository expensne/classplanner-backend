using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class ClassbookContext : DbContext
{
    public DbSet<Exam> Exams { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Score> Scores { get; set; } = null!;
    public DbSet<Postscript> Postscript { get; set; } = null!;

    public string DbPath { get; }

    public ClassbookContext(DbContextOptions<ClassbookContext> options) : base(options)
    {   
        // Create folder db if it doesn't exist
        Directory.CreateDirectory("db");
        DbPath = Path.Join("db/sqlite.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>()
            .Navigation(e => e.GradingScale)
            .AutoInclude();

        modelBuilder.Entity<Exam>()
            .Navigation(e => e.Scores)
            .AutoInclude();

        modelBuilder.Entity<Exam>()
            .Navigation(e => e.Postscripts)
            .AutoInclude();

        modelBuilder.Entity<Student>()
            .Navigation(e => e.Scores)
            .AutoInclude();

        modelBuilder.Entity<Student>()
            .Navigation(e => e.Postscripts)
            .AutoInclude();
    }
}