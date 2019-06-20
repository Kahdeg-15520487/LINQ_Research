﻿// <auto-generated />
using System;
using ChessServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChessServer.Migrations
{
    [DbContext(typeof(ChessDbContext))]
    [Migration("20190619085734_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChessServer.Dal.BoardState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MatchId");

                    b.Property<int>("Turn");

                    b.Property<bool>("Who");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("BoardStates");
                });

            modelBuilder.Entity("ChessServer.Dal.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("FinishedDate");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("ChessServer.Dal.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChessServer.Dal.BoardState", b =>
                {
                    b.HasOne("ChessServer.Dal.Match", "Match")
                        .WithMany("BoardStates")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}