﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HairSalon.Migrations
{
    [DbContext(typeof(HairSalonDbContext))]
    partial class HairSalonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Salon.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AppointmentTime")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentTime = new DateTime(2024, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            StylistId = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentTime = new DateTime(2024, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            StylistId = 2
                        },
                        new
                        {
                            Id = 3,
                            AppointmentTime = new DateTime(2024, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 4,
                            StylistId = 3
                        },
                        new
                        {
                            Id = 4,
                            AppointmentTime = new DateTime(2024, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            StylistId = 4
                        });
                });

            modelBuilder.Entity("Salon.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 2,
                            ServiceId = 3
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 3,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 5,
                            AppointmentId = 4,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 6,
                            AppointmentId = 3,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 7,
                            AppointmentId = 4,
                            ServiceId = 2
                        });
                });

            modelBuilder.Entity("Salon.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main Street",
                            Email = "dwight@example.com",
                            FirstName = "Dwight",
                            LastName = "Schrute"
                        },
                        new
                        {
                            Id = 2,
                            Address = "321 Oak Avenue",
                            Email = "jim@example.com",
                            FirstName = "Jim",
                            LastName = "Halpert"
                        },
                        new
                        {
                            Id = 3,
                            Address = "456 Oak Avenue",
                            Email = "mike@example.com",
                            FirstName = "Michael",
                            LastName = "Scott"
                        },
                        new
                        {
                            Id = 4,
                            Address = "456 Bark Street",
                            Email = "stanley@example.com",
                            FirstName = "Stanley",
                            LastName = "Hudson"
                        },
                        new
                        {
                            Id = 5,
                            Address = "222 Oak Avenue",
                            Email = "kelly@example.com",
                            FirstName = "Kelly",
                            LastName = "Kapoor"
                        },
                        new
                        {
                            Id = 6,
                            Address = "111 Oak Avenue",
                            Email = "phyl@example.com",
                            FirstName = "Phyllis",
                            LastName = "Vance"
                        },
                        new
                        {
                            Id = 7,
                            Address = "899 Bark Street",
                            Email = "jan@example.com",
                            FirstName = "Jan",
                            LastName = "Levinson"
                        });
                });

            modelBuilder.Entity("Salon.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Haircut",
                            Price = 24.99m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beard Trim",
                            Price = 19.99m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hair Color",
                            Price = 49.99m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Perm",
                            Price = 69.99m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hair Extensions",
                            Price = 99.99m
                        });
                });

            modelBuilder.Entity("Salon.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main Street",
                            Email = "will@example.com",
                            FirstName = "Will",
                            IsActive = true,
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Address = "321 This Street",
                            Email = "chloe@example.com",
                            FirstName = "Chloe",
                            IsActive = true,
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            Address = "456 That Street",
                            Email = "mckenzie@example.com",
                            FirstName = "Mckenzie",
                            IsActive = true,
                            LastName = "Stewart"
                        },
                        new
                        {
                            Id = 4,
                            Address = "789 Other Street",
                            Email = "hillary@example.com",
                            FirstName = "Hillary",
                            IsActive = true,
                            LastName = "West"
                        },
                        new
                        {
                            Id = 5,
                            Address = "1011 Over Street",
                            Email = "ethan@example.com",
                            FirstName = "Ethan",
                            IsActive = true,
                            LastName = "Watson"
                        });
                });

            modelBuilder.Entity("Salon.Models.Appointment", b =>
                {
                    b.HasOne("Salon.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salon.Models.Stylist", "Stylist")
                        .WithMany("Appointments")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("Salon.Models.AppointmentService", b =>
                {
                    b.HasOne("Salon.Models.Appointment", "Appointment")
                        .WithMany("Services")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salon.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Salon.Models.Appointment", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Salon.Models.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Salon.Models.Stylist", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
