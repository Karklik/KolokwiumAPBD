using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{
    public class GamesDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ChampionshipTeam> ChamptionshipTeams { get; set; }
        public DbSet<Championship> Championships { get; set; }

        public GamesDbContext() { }
        public GamesDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(mb =>
            {
                mb.HasKey(p => p.IdPlayer);
                mb.Property(p => p.IdPlayer).UseIdentityColumn();
                mb.Property(p => p.FirstName).HasMaxLength(30).IsRequired();
                mb.Property(p => p.LastName).HasMaxLength(50).IsRequired();
                mb.Property(p => p.DateOfBirth).IsRequired();
                mb.ToTable("Player");
            });

            modelBuilder.Entity<PlayerTeam>(mb =>
            {
                mb.HasKey(pt => new { pt.IdPlayer, pt.IdTeam });
                mb.HasIndex(pt => pt.IdPlayer);
                mb.HasIndex(pt => pt.IdTeam);
                mb.Property(pt => pt.NumOnShirt).IsRequired();
                mb.Property(pt => pt.Comment).HasMaxLength(300);
                mb.HasOne(pt => pt.Player)
                    .WithMany(p => p.PlayerTeams)
                    .HasForeignKey(pt => pt.IdPlayer);
                mb.HasOne(pt => pt.Team)
                    .WithMany(t => t.PlayerTeams)
                    .HasForeignKey(pt => pt.IdTeam);
                mb.ToTable("Player_Team");
            });

            modelBuilder.Entity<Team>(mb =>
            {
                mb.HasKey(t => t.IdTeam);
                mb.Property(t => t.IdTeam).UseIdentityColumn();
                mb.Property(t => t.TeamName).HasMaxLength(30).IsRequired();
                mb.Property(t => t.MaxAge).IsRequired();
                mb.ToTable("Team");
            });

            modelBuilder.Entity<Championship>(mb =>
            {
                mb.HasKey(c => c.IdChamptionship);
                mb.Property(c => c.IdChamptionship).UseIdentityColumn();
                mb.Property(c => c.OfficialName).HasMaxLength(100).IsRequired();
                mb.Property(c => c.Year).IsRequired();
                mb.ToTable("Championship");
            });

            modelBuilder.Entity<ChampionshipTeam>(mb =>
            {
                mb.HasKey(cp => new { cp.IdTeam, cp.IdChampionship });
                mb.HasIndex(cp => cp.IdTeam);
                mb.HasIndex(cp => cp.IdChampionship);
                mb.HasOne(cp => cp.Team)
                    .WithMany(t => t.ChamptionshipTeams)
                    .HasForeignKey(cp => cp.IdTeam);
                mb.HasOne(cp => cp.Championship)
                    .WithMany(c => c.ChamptionshipTeams)
                    .HasForeignKey(cp => cp.IdChampionship);
                mb.ToTable("Championship_Team");
            });
        }
    }
}
