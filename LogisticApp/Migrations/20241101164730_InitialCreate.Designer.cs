﻿// <auto-generated />
using System;
using LogisticApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogisticApp.Migrations
{
    [DbContext(typeof(LogisticAppContext))]
    [Migration("20241101164730_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LogisticApp.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("address_id");

                    b.Property<Guid>("CityId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("StreetId")
                        .HasColumnType("binary(16)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("HouseId");

                    b.HasIndex("StreetId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("LogisticApp.Model.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("building_id");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("binary(16)")
                        .HasColumnName("house_id");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("building_number");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("LogisticApp.Model.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("city_id");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("binary(16)")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city_name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("LogisticApp.Model.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country_name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("LogisticApp.Model.House", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("house_id");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("house_number");

                    b.Property<Guid>("StreetId")
                        .HasColumnType("binary(16)")
                        .HasColumnName("street_id");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("LogisticApp.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("order_id");

                    b.Property<int>("CargoWeightInGrams")
                        .HasColumnType("int")
                        .HasColumnName("cargo_weight_in_grams");

                    b.Property<DateTime>("CreationDtm")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("order_creation_dtm");

                    b.Property<Guid>("RecipientAddressId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("SenderAdressId")
                        .HasColumnType("binary(16)");

                    b.Property<int>("UniqueNumber")
                        .HasColumnType("int")
                        .HasColumnName("order_unique_number");

                    b.HasKey("Id");

                    b.HasIndex("RecipientAddressId");

                    b.HasIndex("SenderAdressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LogisticApp.Model.Street", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)")
                        .HasColumnName("street_id");

                    b.Property<Guid>("CityId")
                        .HasColumnType("binary(16)")
                        .HasColumnName("city_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("street_name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("LogisticApp.Model.Address", b =>
                {
                    b.HasOne("LogisticApp.Model.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticApp.Model.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticApp.Model.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("House");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("LogisticApp.Model.Building", b =>
                {
                    b.HasOne("LogisticApp.Model.House", "House")
                        .WithMany("Buildings")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("LogisticApp.Model.City", b =>
                {
                    b.HasOne("LogisticApp.Model.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LogisticApp.Model.House", b =>
                {
                    b.HasOne("LogisticApp.Model.Street", "Street")
                        .WithMany("Houses")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("LogisticApp.Model.Order", b =>
                {
                    b.HasOne("LogisticApp.Model.Address", "RecipientAddress")
                        .WithMany()
                        .HasForeignKey("RecipientAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticApp.Model.Address", "SenderAdress")
                        .WithMany()
                        .HasForeignKey("SenderAdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipientAddress");

                    b.Navigation("SenderAdress");
                });

            modelBuilder.Entity("LogisticApp.Model.Street", b =>
                {
                    b.HasOne("LogisticApp.Model.City", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LogisticApp.Model.City", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("LogisticApp.Model.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("LogisticApp.Model.House", b =>
                {
                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("LogisticApp.Model.Street", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}
