﻿// <auto-generated />
using DeveloperCodingTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeveloperCodingTest.Migrations
{
    [DbContext(typeof(DeveloperCodingContext))]
    [Migration("20210127095002_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DeveloperCodingTest.Models.Membership", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("MembershipTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("AccountBalance")
                        .HasPrecision(9, 4)
                        .HasColumnType("decimal(9,4)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "MembershipTypeId");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            MembershipTypeId = 1,
                            AccountBalance = 10.45m,
                            Number = 111
                        },
                        new
                        {
                            PersonId = 1,
                            MembershipTypeId = 2,
                            AccountBalance = 11.45m,
                            Number = 111
                        },
                        new
                        {
                            PersonId = 2,
                            MembershipTypeId = 1,
                            AccountBalance = 12.00m,
                            Number = 333
                        },
                        new
                        {
                            PersonId = 3,
                            MembershipTypeId = 1,
                            AccountBalance = 12.00m,
                            Number = 444
                        });
                });

            modelBuilder.Entity("DeveloperCodingTest.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MembershipType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Primary"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Secondary"
                        });
                });

            modelBuilder.Entity("DeveloperCodingTest.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ForeName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Aaaaa@Xxxxx.com",
                            ForeName = "Aaaaa",
                            SurName = "Xxxxx"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Bbbbb@Yyyyy.com",
                            ForeName = "Bbbbb",
                            SurName = "Yyyyy"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Ccccc@Zzzzz.com",
                            ForeName = "Ccccc",
                            SurName = "Zzzzz"
                        });
                });

            modelBuilder.Entity("DeveloperCodingTest.Models.Membership", b =>
                {
                    b.HasOne("DeveloperCodingTest.Models.MembershipType", "MembershipType")
                        .WithMany("Memberships")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeveloperCodingTest.Models.Person", "Person")
                        .WithMany("Memberships")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DeveloperCodingTest.Models.MembershipType", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("DeveloperCodingTest.Models.Person", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
