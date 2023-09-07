﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using the_squad_server.Data;

#nullable disable

namespace the_squad_server.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("the_squad_server.Models.Creator", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreatorId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileDescription")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreatorId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("the_squad_server.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<bool>("Generic")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("the_squad_server.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerConnectionPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServerConnectionPort")
                        .HasColumnType("int");

                    b.Property<string>("ServerDNSAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServerGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServerInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("the_squad_server.Models.ServerRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("ServerRoles");
                });

            modelBuilder.Entity("the_squad_server.Models.StreamingService", b =>
                {
                    b.Property<int>("StreamingServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StreamingServiceId"));

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<bool>("Generic")
                        .HasColumnType("bit");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StreamingServiceId");

                    b.HasIndex("CreatorId");

                    b.ToTable("StreamingServices");
                });

            modelBuilder.Entity("the_squad_server.Models.Game", b =>
                {
                    b.HasOne("the_squad_server.Models.Creator", "CreatorAssignment")
                        .WithMany("Games")
                        .HasForeignKey("CreatorId");

                    b.Navigation("CreatorAssignment");
                });

            modelBuilder.Entity("the_squad_server.Models.ServerRole", b =>
                {
                    b.HasOne("the_squad_server.Models.Server", "ServerAssignment")
                        .WithMany("ServerRoleNames")
                        .HasForeignKey("ServerId");

                    b.Navigation("ServerAssignment");
                });

            modelBuilder.Entity("the_squad_server.Models.StreamingService", b =>
                {
                    b.HasOne("the_squad_server.Models.Creator", "CreatorAssignment")
                        .WithMany("StreamingServices")
                        .HasForeignKey("CreatorId");

                    b.Navigation("CreatorAssignment");
                });

            modelBuilder.Entity("the_squad_server.Models.Creator", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("StreamingServices");
                });

            modelBuilder.Entity("the_squad_server.Models.Server", b =>
                {
                    b.Navigation("ServerRoleNames");
                });
#pragma warning restore 612, 618
        }
    }
}