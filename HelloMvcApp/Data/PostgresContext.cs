using System;
using WOD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace WOD.WebUI.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<FootballClub> FootballClubs { get; set; }

    public virtual DbSet<News> News { get; set; }

    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<PostgresContext>();
            db.Database.Migrate();
        }

        host.Run();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=250702iI;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admins_pkey");

            entity.ToTable("admins");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<FootballClub>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EPL_Table_pkey");

            entity.ToTable("footballclub_info", tb => tb.HasComment("Статистика футбольных клубов АПЛ 2024."));

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Ties).HasColumnName("ties");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Games).HasColumnName("games");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.GoalsAgainst).HasColumnName("goalsagainst");
            entity.Property(e => e.GoalsFor).HasColumnName("goalsfor");
            entity.Property(e => e.GoalsDifference).HasColumnName("goalsdifference");
            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.Losses).HasColumnName("losses");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Wins).HasColumnName("wins");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("news_pkey");

            entity.ToTable(tb => tb.HasComment("Новости\nСодержит: Заголовок, картинку, текст новости и ID."));

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("news_image");
            entity.Property(e => e.Text).HasColumnName("news_text");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
