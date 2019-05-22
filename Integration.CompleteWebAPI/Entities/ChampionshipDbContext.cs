using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.CompleteWebAPI.Entities
{
    public class ChampionshipDbContext : DbContext
    {
        public DbSet<ChampionshipEntity> Championships { get; set; }
        public DbSet<FederationEntity> Federations { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TitleEntity> Titles { get; set; }

        public ChampionshipDbContext(DbContextOptions<ChampionshipDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FederationEntity>().HasData(
                new FederationEntity()
                {
                    Id = Guid.Parse("7B1E286E-6FAA-416A-8867-504DEC147C84"),
                    Acronym = "FPF",
                    Federation = "Federacao Paulista de Futebol"
                },
                new FederationEntity()
                {
                    Id = Guid.Parse("D597BC12-E5D6-4A68-93DF-EFA52E44ABB6"),
                    Acronym = "CBF",
                    Federation = "Confederacao Brasileira de Futebol"
                },
                new FederationEntity()
                {
                    Id = Guid.Parse("601171DE-77AB-480D-A99D-054449E07FCF"),
                    Acronym = "FIFA",
                    Federation = "Federation Internationale de Football Association"
                },
                new FederationEntity()
                {
                    Id = Guid.Parse("C9496AF1-AC10-4E9F-8E7A-E92A49A2A337"),
                    Acronym = "CONMEBOL",
                    Federation = "Confederacion Sudamericana de Futbol"
                }
            );

            modelBuilder.Entity<TeamEntity>().HasData(
                new TeamEntity()
                {
                    Id = Guid.Parse("0DDDE795-1460-43C0-A246-AE8168106F3F"),
                    Name = "Sport Club Corinthians Paulista",
                    FoundationDate = new DateTime(1910, 9, 1),
                    Mascot = null,
                    Logo = null
                }
            );

            modelBuilder.Entity<ChampionshipEntity>().HasData(
                new ChampionshipEntity()
                {
                    Id = Guid.Parse("0D5891D9-9997-4E87-8316-33CF9C55B154"),
                    FederationId = Guid.Parse("7B1E286E-6FAA-416A-8867-504DEC147C84"),
                    Championship = "Campeonato Paulista de Futebol",
                    Trophy = null
                },
                new ChampionshipEntity()
                {
                    Id = Guid.Parse("581C69CB-F267-467C-8ADD-DDE491FCFEB7"),
                    FederationId = Guid.Parse("D597BC12-E5D6-4A68-93DF-EFA52E44ABB6"),
                    Championship = "Brasileirao",
                    Trophy = null
                },
                new ChampionshipEntity()
                {
                    Id = Guid.Parse("ED31E62D-BE30-4588-8EEB-A072BDF37C25"),
                    FederationId = Guid.Parse("C9496AF1-AC10-4E9F-8E7A-E92A49A2A337"),
                    Championship = "Libertadores da America",
                    Trophy = null
                },
                new ChampionshipEntity()
                {
                    Id = Guid.Parse("8089FEC4-5072-44EF-A3C6-560822D09DB1"),
                    FederationId = Guid.Parse("601171DE-77AB-480D-A99D-054449E07FCF"),
                    Championship = "Mundial de Clubes",
                    Trophy = null
                }
            );

            modelBuilder.Entity<TitleEntity>().HasData(
                new TitleEntity()
                {
                    Id = Guid.Parse("3C91388-07BD-451C-BF84-67707319D15D"),
                    Year = 2012,
                    Conquered = new DateTime(2012,12,16),
                    ChampionshipId = Guid.Parse("8089FEC4-5072-44EF-A3C6-560822D09DB1"),
                    TeamId = Guid.Parse("0DDDE795-1460-43C0-A246-AE8168106F3F")
                },
                new TitleEntity()
                {
                    Id = Guid.Parse("C9D0A375-BCB8-4B2E-A792-CD20EFE59DBD"),
                    Year = 2012,
                    Conquered = new DateTime(2012, 7, 4),
                    ChampionshipId = Guid.Parse("ED31E62D-BE30-4588-8EEB-A072BDF37C25"),
                    TeamId = Guid.Parse("0DDDE795-1460-43C0-A246-AE8168106F3F")
                },
                new TitleEntity()
                {
                    Id = Guid.Parse("0D5891D9-9997-4E87-8316-33CF9C55B154"),
                    Year = 2019,
                    Conquered = new DateTime(2019, 4, 20),
                    ChampionshipId = Guid.Parse("0D5891D9-9997-4E87-8316-33CF9C55B154"),
                    TeamId = Guid.Parse("0DDDE795-1460-43C0-A246-AE8168106F3F")
                },
                new TitleEntity()
                {
                    Id = Guid.Parse("15F1C953-2FC3-4F62-B0B8-F1A899BB9D4B"),
                    Year = 2017,
                    Conquered = new DateTime(2017, 15, 11),
                    ChampionshipId = Guid.Parse("581C69CB-F267-467C-8ADD-DDE491FCFEB7"),
                    TeamId = Guid.Parse("0DDDE795-1460-43C0-A246-AE8168106F3F")
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
