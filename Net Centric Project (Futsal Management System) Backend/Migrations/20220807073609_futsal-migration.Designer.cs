﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net_Centric_Project__Futsal_Management_System__Backend.Models;

#nullable disable

namespace Net_Centric_Project__Futsal_Management_System__Backend.Migrations
{
    [DbContext(typeof(FutsalManagementDBContext))]
    [Migration("20220807073609_futsal-migration")]
    partial class futsalmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Net_Centric_Project__Futsal_Management_System__Backend.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("AdminId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Net_Centric_Project__Futsal_Management_System__Backend.Models.Futsal", b =>
                {
                    b.Property<int>("FutsalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FutsalId"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<string>("FutsalDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("FutsalEndTime")
                        .HasColumnType("time");

                    b.Property<string>("FutsalLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FutsalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("FutsalStartTime")
                        .HasColumnType("time");

                    b.HasKey("FutsalId");

                    b.HasIndex("AdminId");

                    b.ToTable("Futsals");
                });

            modelBuilder.Entity("Net_Centric_Project__Futsal_Management_System__Backend.Models.Futsal", b =>
                {
                    b.HasOne("Net_Centric_Project__Futsal_Management_System__Backend.Models.Admin", null)
                        .WithMany("Futsals")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Net_Centric_Project__Futsal_Management_System__Backend.Models.Admin", b =>
                {
                    b.Navigation("Futsals");
                });
#pragma warning restore 612, 618
        }
    }
}
