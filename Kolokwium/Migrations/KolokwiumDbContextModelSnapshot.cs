﻿// <auto-generated />
using System;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kolokwium.Migrations
{
    [DbContext(typeof(GamesDbContext))]
    partial class KolokwiumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Kolokwium.Models.Championship", b =>
                {
                    b.Property<int>("IdChamptionship")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("OfficialName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("IdChamptionship");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("Kolokwium.Models.ChampionshipTeam", b =>
                {
                    b.Property<int>("IdTeam")
                        .HasColumnType("integer");

                    b.Property<int>("IdChampionship")
                        .HasColumnType("integer");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("IdTeam", "IdChampionship");

                    b.HasIndex("IdChampionship");

                    b.HasIndex("IdTeam");

                    b.ToTable("Championship_Team");
                });

            modelBuilder.Entity("Kolokwium.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdPlayer");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Kolokwium.Models.PlayerTeam", b =>
                {
                    b.Property<int>("IdPlayer")
                        .HasColumnType("integer");

                    b.Property<int>("IdTeam")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .HasColumnType("character varying(300)")
                        .HasMaxLength(300);

                    b.Property<int>("NumOnShirt")
                        .HasColumnType("integer");

                    b.HasKey("IdPlayer", "IdTeam");

                    b.HasIndex("IdPlayer");

                    b.HasIndex("IdTeam");

                    b.ToTable("Player_Team");
                });

            modelBuilder.Entity("Kolokwium.Models.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MaxAge")
                        .HasColumnType("integer");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdTeam");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Kolokwium.Models.ChampionshipTeam", b =>
                {
                    b.HasOne("Kolokwium.Models.Championship", "Championship")
                        .WithMany("ChamptionshipTeams")
                        .HasForeignKey("IdChampionship")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium.Models.Team", "Team")
                        .WithMany("ChamptionshipTeams")
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kolokwium.Models.PlayerTeam", b =>
                {
                    b.HasOne("Kolokwium.Models.Player", "Player")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("IdPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium.Models.Team", "Team")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("IdTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
