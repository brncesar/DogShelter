﻿// <auto-generated />
using System;
using DogShelter.Infrastructure.Data.DbCtx;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DogShelter.Infrastructure.Migrations
{
    [DbContext(typeof(DogShelterDbContext))]
    partial class DogShelterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("DogShelter.Domain.Entities.BreedEntity.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("T02_id_Breed")
                        .HasColumnOrder(1);

                    b.Property<int>("ApiId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_BreedIdOnDogApi");

                    b.Property<string>("BredFor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("tx_BredFor");

                    b.Property<string>("BreedGroup")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("tx_BredGroup");

                    b.Property<int>("HeightAverageImperial")
                        .HasColumnType("INTEGER")
                        .HasColumnName("nu_HeightAverageImperial");

                    b.Property<int>("HeightAverageMetric")
                        .HasColumnType("INTEGER")
                        .HasColumnName("nu_HeightAverageMetric");

                    b.Property<string>("LifeSpan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("tx_LifeSpan");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("na_Breed");

                    b.Property<string>("Temperament")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("tx_Temperament");

                    b.HasKey("Id");

                    b.HasIndex("ApiId")
                        .IsUnique();

                    b.ToTable("T02_Breed", (string)null);
                });

            modelBuilder.Entity("DogShelter.Domain.Entities.DogEntity.Dog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("T01_id_Dog")
                        .HasColumnOrder(1);

                    b.Property<Guid>("BreedId")
                        .HasColumnType("TEXT")
                        .HasColumnName("T02_id_Breed");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("na_Dog");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("T01_Dog", (string)null);
                });

            modelBuilder.Entity("DogShelter.Domain.Entities.DogEntity.Dog", b =>
                {
                    b.HasOne("DogShelter.Domain.Entities.BreedEntity.Breed", "Breed")
                        .WithMany("Dogs")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("DogShelter.Domain.Entities.BreedEntity.Breed", b =>
                {
                    b.Navigation("Dogs");
                });
#pragma warning restore 612, 618
        }
    }
}