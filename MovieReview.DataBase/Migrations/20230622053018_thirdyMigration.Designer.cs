﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieReviewDataBase;

#nullable disable

namespace MovieReview.Database.Migrations
{
    [DbContext(typeof(MovieReviewContext))]
    [Migration("20230622053018_thirdyMigration")]
    partial class thirdyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Actors", (string)null);
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.ActorTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ActorId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TitleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TitleId");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("TitleId");

                    b.HasIndex("UserId");

                    b.ToTable("ActorsTitles", (string)null);
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Directors", (string)null);
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<int>("Note")
                        .HasColumnType("int")
                        .HasColumnName("Note");

                    b.Property<Guid>("TitleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TitleId");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Title", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DirectorId");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("Duration");

                    b.Property<int>("Genre")
                        .HasColumnType("int")
                        .HasColumnName("Genre");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Synopsis");

                    b.Property<string>("TitleMovie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TitleMovie");

                    b.Property<int>("TypeMovie")
                        .HasColumnType("int")
                        .HasColumnName("TypeMovie");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("UserId");

                    b.ToTable("Titles", (string)null);
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsAdministrator")
                        .HasColumnType("bit")
                        .HasColumnName("IsAdministrator");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Actor", b =>
                {
                    b.HasOne("MovieReview.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.ActorTitle", b =>
                {
                    b.HasOne("MovieReview.Core.Domain.Entities.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieReview.Core.Domain.Entities.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieReview.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Actor");

                    b.Navigation("Title");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Director", b =>
                {
                    b.HasOne("MovieReview.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Review", b =>
                {
                    b.HasOne("MovieReview.Core.Domain.Entities.Title", "Title")
                        .WithMany("Reviews")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieReview.Core.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Title");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Title", b =>
                {
                    b.HasOne("MovieReview.Core.Domain.Entities.Director", "Director")
                        .WithMany("Titles")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieReview.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Director");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.User", b =>
                {
                    b.HasOne("MovieReview.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Director", b =>
                {
                    b.Navigation("Titles");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.Title", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MovieReview.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}