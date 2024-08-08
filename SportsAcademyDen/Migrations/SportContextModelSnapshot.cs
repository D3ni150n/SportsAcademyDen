﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsAcademyDen.Data;

#nullable disable

namespace SportsAcademyDen.Migrations
{
    [DbContext(typeof(SportContext))]
    partial class SportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SportsAcademyDen.Models.Coach", b =>
                {
                    b.Property<int>("CoachID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoachID"), 1L, 1);

                    b.Property<string>("CoachAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportID")
                        .HasColumnType("int");

                    b.HasKey("CoachID");

                    b.HasIndex("SportID");

                    b.ToTable("Coach", (string)null);
                });

            modelBuilder.Entity("SportsAcademyDen.Models.Fixture", b =>
                {
                    b.Property<int>("FixtureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FixtureID"), 1L, 1);

                    b.Property<string>("FixtureLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FixtureStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FixtureTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int>("SportID")
                        .HasColumnType("int");

                    b.HasKey("FixtureID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("SportID");

                    b.ToTable("Fixture", (string)null);
                });

            modelBuilder.Entity("SportsAcademyDen.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<DateTime>("FixtureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PlayerID");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("SportsAcademyDen.Models.Sport", b =>
                {
                    b.Property<int>("SportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SportID"), 1L, 1);

                    b.Property<string>("SportName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportID");

                    b.ToTable("Sport", (string)null);
                });

            modelBuilder.Entity("SportsAcademyDen.Models.Coach", b =>
                {
                    b.HasOne("SportsAcademyDen.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SportsAcademyDen.Models.Fixture", b =>
                {
                    b.HasOne("SportsAcademyDen.Models.Player", "Player")
                        .WithMany("Fixtures")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsAcademyDen.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SportsAcademyDen.Models.Player", b =>
                {
                    b.Navigation("Fixtures");
                });
#pragma warning restore 612, 618
        }
    }
}
