﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore_Configurations.Migrations
{
    [DbContext(typeof(ConfigurationDbContext))]
    [Migration("20240315114819_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ayırıcı")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("BaseProp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BaseEntitys");

                    b.HasDiscriminator<string>("Ayırıcı").HasValue("BaseEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Departman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departmans");
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("ComputedColumn")
                        .HasColumnType("real");

                    b.Property<int>("ConcurrencyCheckColumn")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmanId")
                        .HasColumnType("int");

                    b.Property<string>("Midname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NotMappedPropumuz")
                        .HasColumnType("int");

                    b.Property<float>("Prim")
                        .HasColumnType("real");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmanId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Derived1", b =>
                {
                    b.HasBaseType("BaseEntity");

                    b.Property<string>("Derived1Prop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Derived1");
                });

            modelBuilder.Entity("Derived2", b =>
                {
                    b.HasBaseType("BaseEntity");

                    b.Property<string>("Derived2Prop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Derived2");
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.HasOne("Departman", "Departman")
                        .WithMany("Personlar")
                        .HasForeignKey("DepartmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departman");
                });

            modelBuilder.Entity("Departman", b =>
                {
                    b.Navigation("Personlar");
                });
#pragma warning restore 612, 618
        }
    }
}
