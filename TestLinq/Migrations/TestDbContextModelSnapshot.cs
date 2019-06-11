﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestLinq;

namespace TestLinq.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestLinq.Entity.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3d53120-e90b-49d6-8852-38d90c9097d6"),
                            Name = "batanvlog",
                            UserId = new Guid("bcbadee2-df4b-457f-b294-6b3c8746b4e1")
                        });
                });

            modelBuilder.Entity("TestLinq.Entity.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("969cbbfe-6ae5-47de-abec-e363a2dd9bc1"),
                            BlogId = new Guid("a3d53120-e90b-49d6-8852-38d90c9097d6"),
                            Content = "Cac chau oi ...",
                            Name = "100 canh ga chien nuoc mam"
                        });
                });

            modelBuilder.Entity("TestLinq.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bcbadee2-df4b-457f-b294-6b3c8746b4e1"),
                            Name = "batan"
                        });
                });

            modelBuilder.Entity("TestLinq.Entity.Blog", b =>
                {
                    b.HasOne("TestLinq.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestLinq.Entity.Post", b =>
                {
                    b.HasOne("TestLinq.Entity.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
