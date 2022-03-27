﻿// <auto-generated />
using System;
using E_Learning.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace E_Learning.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("E_Learning.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContentBody")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ThemeId")
                        .HasColumnType("uuid");

                    b.Property<string>("VideoLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("E_Learning.Domain.FileModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<string>("file")
                        .HasColumnType("text");

                    b.Property<string>("file_name")
                        .HasColumnType("text");

                    b.Property<string>("file_size")
                        .HasColumnType("text");

                    b.Property<string>("file_type")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("CourseId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("E_Learning.Domain.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("E_Learning.Domain.Theme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("E_Learning.Domain.Course", b =>
                {
                    b.HasOne("E_Learning.Domain.Theme", null)
                        .WithMany("Courses")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Learning.Domain.FileModel", b =>
                {
                    b.HasOne("E_Learning.Domain.Course", null)
                        .WithMany("Sources")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("E_Learning.Domain.Course", b =>
                {
                    b.Navigation("Sources");
                });

            modelBuilder.Entity("E_Learning.Domain.Theme", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
