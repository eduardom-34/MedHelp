﻿// <auto-generated />
using System;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedHelpApi.Migrations
{
    [DbContext(typeof(MedHelpContext))]
    partial class MedHelpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoctorSpecialty", b =>
                {
                    b.Property<int>("DoctorsDoctorID")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtiesSpecialtyID")
                        .HasColumnType("int");

                    b.HasKey("DoctorsDoctorID", "SpecialtiesSpecialtyID");

                    b.HasIndex("SpecialtiesSpecialtyID");

                    b.ToTable("DoctorSpecialty");
                });

            modelBuilder.Entity("MedHelpApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MedHelpApi.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedHelpApi.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("ScheduleID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("MedHelpApi.Models.ScheduleDate", b =>
                {
                    b.Property<int>("ScheduleDateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleDateID"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ScheduleID")
                        .HasColumnType("int");

                    b.HasKey("ScheduleDateID");

                    b.HasIndex("ScheduleID");

                    b.ToTable("ScheduleDate");
                });

            modelBuilder.Entity("MedHelpApi.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialtyID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialtyID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("MedHelpApi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DoctorSpecialty", b =>
                {
                    b.HasOne("MedHelpApi.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsDoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedHelpApi.Models.Specialty", null)
                        .WithMany()
                        .HasForeignKey("SpecialtiesSpecialtyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedHelpApi.Models.Schedule", b =>
                {
                    b.HasOne("MedHelpApi.Models.Doctor", "Doctor")
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("MedHelpApi.Models.ScheduleDate", b =>
                {
                    b.HasOne("MedHelpApi.Models.Schedule", "Schedule")
                        .WithMany("ScheduleDates")
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("MedHelpApi.Models.Specialty", b =>
                {
                    b.HasOne("MedHelpApi.Models.Category", "Category")
                        .WithMany("Specialties")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MedHelpApi.Models.Category", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("MedHelpApi.Models.Doctor", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("MedHelpApi.Models.Schedule", b =>
                {
                    b.Navigation("ScheduleDates");
                });
#pragma warning restore 612, 618
        }
    }
}
