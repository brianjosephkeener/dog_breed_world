﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dog_breed_world.Models;

#nullable disable

namespace dog_breed_world.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("dog_breed_world.Models.GoogleUser", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("aud")
                        .HasColumnType("longtext");

                    b.Property<string>("azp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<bool?>("email_verified")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("exp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("family_name")
                        .HasColumnType("longtext");

                    b.Property<string>("given_name")
                        .HasColumnType("longtext");

                    b.Property<string>("hd")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("iat")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("iss")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("jti")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<int?>("nbf")
                        .HasColumnType("int");

                    b.Property<string>("picture")
                        .HasColumnType("longtext");

                    b.Property<string>("sub")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("GoogleUsers");
                });

            modelBuilder.Entity("dog_breed_world.Models.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GivenName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}