﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mmi.DataAccess;

#nullable disable

namespace Mmi.Api.Migrations
{
    [DbContext(typeof(MedicalInsuranceDb))]
    [Migration("20240219170001_initial-migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Mmi.Core.Domain.InsuranceContract", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Mmi.Core.Domain.InsuranceСase", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("IncidentDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Payment")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("InsuranceСases");
                });

            modelBuilder.Entity("Mmi.Core.Domain.InsuredPerson", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("Bithday")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Pemissions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InsuredPersons");
                });

            modelBuilder.Entity("Mmi.Core.Domain.InsuranceContract", b =>
                {
                    b.HasOne("Mmi.Core.Domain.InsuredPerson", "Person")
                        .WithMany("Contracts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Mmi.Core.Domain.InsuranceСase", b =>
                {
                    b.HasOne("Mmi.Core.Domain.InsuranceContract", "Contract")
                        .WithMany("InsuranceСases")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Mmi.Core.Domain.InsuranceContract", b =>
                {
                    b.Navigation("InsuranceСases");
                });

            modelBuilder.Entity("Mmi.Core.Domain.InsuredPerson", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
