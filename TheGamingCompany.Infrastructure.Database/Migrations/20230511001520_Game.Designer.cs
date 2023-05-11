﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheGamingCompany.Infrastructure.Database;

#nullable disable

namespace TheGamingCompany.Infrastructure.Database.Migrations
{
    [DbContext(typeof(TheGamingCompanyContext))]
    [Migration("20230511001520_Game")]
    partial class Game
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("TheGamingCompany.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TheGamingCompany.Core.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Copies")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamingModeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GamingModeId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TheGamingCompany.Core.Entities.GamingMode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GamingModes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Multi-Player"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Single-Player"
                        });
                });

            modelBuilder.Entity("TheGamingCompany.Core.Entities.Game", b =>
                {
                    b.HasOne("TheGamingCompany.Core.Entities.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("GamingModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheGamingCompany.Core.Entities.GamingMode", "GamingMode")
                        .WithMany("Games")
                        .HasForeignKey("GamingModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("GamingMode");
                });

            modelBuilder.Entity("TheGamingCompany.Core.Entities.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("TheGamingCompany.Core.Entities.GamingMode", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
