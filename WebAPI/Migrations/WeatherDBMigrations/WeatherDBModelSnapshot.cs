﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebAPI.Migrations.WeatherDBMigrations
{
    [DbContext(typeof(WeatherDB))]
    partial class WeatherDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WebAPI.Client.Models.Weather", b =>
                {
                    b.Property<int>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Humidity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Temp")
                        .HasColumnType("REAL");

                    b.HasKey("WeatherId");

                    b.ToTable("WeatherData");
                });
#pragma warning restore 612, 618
        }
    }
}
