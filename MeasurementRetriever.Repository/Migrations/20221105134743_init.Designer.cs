﻿// <auto-generated />
using System;
using MeasurementRetriever.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeasurementRetriever.Repository.Migrations
{
    [DbContext(typeof(MeasurementRetrieverDbContext))]
    [Migration("20221105134743_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MeasurementRetriever.Domain.Models.AgregatedMeasurment", b =>
                {
                    b.Property<long>("MeasurmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MeasurmentId"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PMinus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PPlus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("RegionId")
                        .HasColumnType("bigint");

                    b.HasKey("MeasurmentId");

                    b.HasIndex("RegionId");

                    b.ToTable("AgregatedMeasurments");
                });

            modelBuilder.Entity("MeasurementRetriever.Domain.Models.DatasetInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("isProcessed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DatasetInfo");
                });

            modelBuilder.Entity("MeasurementRetriever.Domain.Models.Region", b =>
                {
                    b.Property<long>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RegionId"), 1L, 1);

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("RegionId");

                    b.HasIndex("RegionName");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("MeasurementRetriever.Domain.Models.AgregatedMeasurment", b =>
                {
                    b.HasOne("MeasurementRetriever.Domain.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
