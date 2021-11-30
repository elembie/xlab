﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using findabeer.Models;

namespace findabeer.api.Migrations
{
    [DbContext(typeof(FindABeerContext))]
    partial class FindABeerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("findabeer.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("findabeer.Models.Venue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Excerpt")
                        .HasColumnType("text");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Long")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<decimal>("StarsAmenities")
                        .HasColumnType("decimal(2,1)");

                    b.Property<decimal>("StarsAtmosphere")
                        .HasColumnType("decimal(2,1)");

                    b.Property<decimal>("StarsBeer")
                        .HasColumnType("decimal(2,1)");

                    b.Property<decimal>("StarsValue")
                        .HasColumnType("decimal(2,1)");

                    b.Property<long?>("TagId")
                        .HasColumnType("bigint");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("text");

                    b.Property<string>("Twitter")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("findabeer.Models.VenueTag", b =>
                {
                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.Property<long>("VenueId")
                        .HasColumnType("bigint");

                    b.HasKey("TagId", "VenueId");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueTags");
                });

            modelBuilder.Entity("findabeer.Models.Venue", b =>
                {
                    b.HasOne("findabeer.Models.Tag", null)
                        .WithMany("Venues")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("findabeer.Models.VenueTag", b =>
                {
                    b.HasOne("findabeer.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("findabeer.Models.Venue", "Venue")
                        .WithMany("Tags")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("findabeer.Models.Tag", b =>
                {
                    b.Navigation("Venues");
                });

            modelBuilder.Entity("findabeer.Models.Venue", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
