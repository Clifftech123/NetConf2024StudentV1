﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetConf2024StudentV1.Data;

#nullable disable

namespace NetConf2024StudentV1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241115150840_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetConf2024StudentV1.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 20,
                            Email = "john.doe@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Age = 22,
                            Email = "jane.doe@example.com",
                            Name = "Jane Doe"
                        },
                        new
                        {
                            Id = 3,
                            Age = 23,
                            Email = "alice.smith@example.com",
                            Name = "Alice Smith"
                        },
                        new
                        {
                            Id = 4,
                            Age = 21,
                            Email = "bob.johnson@example.com",
                            Name = "Bob Johnson"
                        },
                        new
                        {
                            Id = 5,
                            Age = 24,
                            Email = "charlie.brown@example.com",
                            Name = "Charlie Brown"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
