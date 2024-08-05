﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prac_demo_enitity_framework.Models;

#nullable disable

namespace prac_demo_enitity_framework.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    partial class ApplicationDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("prac_demo_enitity_framework.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("AdminAge")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AdminContact")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("AdminDept")
                        .HasColumnType("int");

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });
#pragma warning restore 612, 618
        }
    }
}
