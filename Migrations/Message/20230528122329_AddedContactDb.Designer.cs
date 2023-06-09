﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Santa_Final_ASP.Models.Contexts;

#nullable disable

namespace Santa_Final_ASP.Migrations.Message
{
    [DbContext(typeof(MessageContext))]
    [Migration("20230528122329_AddedContactDb")]
    partial class AddedContactDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Santa_Final_ASP.Models.Entities.MessageUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MessageInfos");
                });

            modelBuilder.Entity("Santa_Final_ASP.Models.Identity.ContactMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MessageInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("SaveEmail")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MessageInfoId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Santa_Final_ASP.Models.Identity.ContactMessage", b =>
                {
                    b.HasOne("Santa_Final_ASP.Models.Entities.MessageUser", "MessageInfo")
                        .WithMany("Messages")
                        .HasForeignKey("MessageInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageInfo");
                });

            modelBuilder.Entity("Santa_Final_ASP.Models.Entities.MessageUser", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
