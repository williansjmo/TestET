﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgency.Infrastructure.Data;

namespace TravelAgency.Infrastructure.Migrations
{
    [DbContext(typeof(TravelAgencyDbContext))]
    partial class TravelAgencyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelAgency.Domain.Entities.Passenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IdentityCard")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Travel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NumberOfSeats")
                        .HasColumnType("float");

                    b.Property<string>("PlaceOfOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TravelCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Travel");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Travellers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PassengerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TravelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TravelId");

                    b.ToTable("Travellers");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Travellers", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Travel", "Travel")
                        .WithMany("Travellers")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Travel", b =>
                {
                    b.Navigation("Travellers");
                });
#pragma warning restore 612, 618
        }
    }
}
