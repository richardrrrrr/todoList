﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todoList.Entity;

#nullable disable

namespace todoList.Migrations
{
    [DbContext(typeof(TodolistDbContext))]
    [Migration("20231207085924_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("todoList.Models.account", b =>
                {
                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrimaryKey"));

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrimaryKey");

                    b.ToTable("Accounts", (string)null);

                    b.HasData(
                        new
                        {
                            PrimaryKey = 1,
                            Id = "user001",
                            Name = "User One",
                            Password = "password001",
                            Role = 1,
                            Status = "V"
                        },
                        new
                        {
                            PrimaryKey = 2,
                            Id = "user002",
                            Name = "User Two",
                            Password = "password002",
                            Role = 2,
                            Status = "V"
                        },
                        new
                        {
                            PrimaryKey = 3,
                            Id = "user003",
                            Name = "User Three",
                            Password = "password003",
                            Role = 1,
                            Status = "X"
                        });
                });

            modelBuilder.Entity("todoList.Models.todolist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Complete_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Todolists ", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Created_at = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsComplete = false,
                            Name = "Task 1 for User One",
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1,
                            Created_at = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsComplete = false,
                            Name = "Task 2 for User One",
                            Priority = 2
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 2,
                            Complete_at = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created_at = new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsComplete = true,
                            Name = "Task 1 for User Two",
                            Priority = 1
                        });
                });

            modelBuilder.Entity("todoList.Models.todolist", b =>
                {
                    b.HasOne("todoList.Models.account", "Account")
                        .WithMany("todolist")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("todoList.Models.account", b =>
                {
                    b.Navigation("todolist");
                });
#pragma warning restore 612, 618
        }
    }
}
