﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPOAPAKmmReceiver.Data;

namespace SPOAPAKmmReceiver.Migrations
{
    [DbContext(typeof(SPOAPAKmmDB))]
    [Migration("20221027061428_ChangeDeviceEntity")]
    partial class ChangeDeviceEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VerificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("VerificationInformation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VerificationOrganization")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TypeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Levels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MeasureItemId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("P1")
                        .HasColumnType("REAL");

                    b.Property<double>("P2")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("MeasureItemId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.MeasPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("MeasPoints");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.MeasureItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AverageE")
                        .HasColumnType("REAL");

                    b.Property<double>("DX")
                        .HasColumnType("REAL");

                    b.Property<string>("E")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Freq")
                        .HasColumnType("REAL");

                    b.Property<int>("MeasPointId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("P1")
                        .HasColumnType("REAL");

                    b.Property<double>("P2")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("MeasPointId");

                    b.ToTable("Measurings");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Device", b =>
                {
                    b.HasOne("SPOAPAKmmReceiver.Entities.Room", "Room")
                        .WithMany("Devices")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SPOAPAKmmReceiver.Entities.DeviceType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.OwnsOne("SPOAPAKmmReceiver.Entities.MeasRange", "Range", b1 =>
                        {
                            b1.Property<int>("DeviceId")
                                .HasColumnType("INTEGER");

                            b1.Property<double>("EndFreq")
                                .HasColumnType("REAL");

                            b1.Property<int>("Id")
                                .HasColumnType("INTEGER");

                            b1.Property<double>("SartFreq")
                                .HasColumnType("REAL");

                            b1.HasKey("DeviceId");

                            b1.ToTable("Devices");

                            b1.WithOwner()
                                .HasForeignKey("DeviceId");
                        });

                    b.Navigation("Range")
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Element", b =>
                {
                    b.HasOne("SPOAPAKmmReceiver.Entities.Room", "Room")
                        .WithMany("Elements")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Levels", b =>
                {
                    b.HasOne("SPOAPAKmmReceiver.Entities.MeasureItem", "MeasureItem")
                        .WithMany("Levels")
                        .HasForeignKey("MeasureItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasureItem");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.MeasPoint", b =>
                {
                    b.HasOne("SPOAPAKmmReceiver.Entities.Element", "Element")
                        .WithMany("Points")
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.MeasureItem", b =>
                {
                    b.HasOne("SPOAPAKmmReceiver.Entities.MeasPoint", "MeasPoint")
                        .WithMany("MeasureItems")
                        .HasForeignKey("MeasPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasPoint");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Room", b =>
                {
                    b.HasOne("SPOAPAKmmReceiver.Entities.Organization", "Organization")
                        .WithMany("Rooms")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Element", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.MeasPoint", b =>
                {
                    b.Navigation("MeasureItems");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.MeasureItem", b =>
                {
                    b.Navigation("Levels");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Organization", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("SPOAPAKmmReceiver.Entities.Room", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Elements");
                });
#pragma warning restore 612, 618
        }
    }
}
