﻿// <auto-generated />
using System;
using Encryptor.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Encryptor.Persistence.Migrations
{
    [DbContext(typeof(EncryptorContext))]
    [Migration("20191202035054_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Encryption.Domain.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cb5cad85-6c33-4fc6-90be-4b5cfebe29ad"),
                            FirstName = "Vlad",
                            LastName = "G",
                            Password = "passwD."
                        },
                        new
                        {
                            Id = new Guid("23eab257-d843-4128-aeda-46176e7f8c26"),
                            FirstName = "Easy",
                            LastName = "E",
                            Password = "EE"
                        },
                        new
                        {
                            Id = new Guid("f8192112-2f3b-4800-be27-7503127ac5db"),
                            FirstName = "Unknown",
                            LastName = "",
                            Password = "nooasswd"
                        },
                        new
                        {
                            Id = new Guid("a318fc34-856b-4c71-8fd4-bdf7ed0df577"),
                            FirstName = "Inkognito",
                            LastName = ";)",
                            Password = "lolHz"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
