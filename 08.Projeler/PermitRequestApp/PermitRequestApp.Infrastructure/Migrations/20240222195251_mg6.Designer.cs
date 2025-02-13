﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PermitRequestApp.Infrastructure.Context;

#nullable disable

namespace PermitRequestApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240222195251_mg6")]
    partial class mg6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PermitRequestApp.Domain.ADUsers.ADUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("ADUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e21cd525-031c-4364-b173-4150a4e18c37"),
                            Email = "munir.ozkul@negzel.net",
                            FirstName = "Münir",
                            LastName = "Özkul",
                            UserType = 30
                        },
                        new
                        {
                            Id = new Guid("59fb152a-2d59-435d-8fc1-cbc35c0f1d82"),
                            Email = "sener.sen@negzel.net",
                            FirstName = "Şener",
                            LastName = "Şen",
                            ManagerId = new Guid("e21cd525-031c-4364-b173-4150a4e18c37"),
                            UserType = 10
                        },
                        new
                        {
                            Id = new Guid("23591451-1cf1-46a5-907a-ee3e52abe394"),
                            Email = "kemal.sunal@negzel.net",
                            FirstName = "Kemal",
                            LastName = "Sunal",
                            ManagerId = new Guid("59fb152a-2d59-435d-8fc1-cbc35c0f1d82"),
                            UserType = 20
                        });
                });

            modelBuilder.Entity("PermitRequestApp.Domain.CumulativeLeaveRequests.CumulativeLeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CumulativeLeaveRequests", (string)null);
                });

            modelBuilder.Entity("PermitRequestApp.Domain.LeaveRequests.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RequestUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkflowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.HasIndex("RequestUserId");

                    b.ToTable("LeaveRequests", (string)null);
                });

            modelBuilder.Entity("PermitRequestApp.Domain.Notifications.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CumulativeLeaveRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CumulativeLeaveRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications", (string)null);
                });

            modelBuilder.Entity("PermitRequestApp.Domain.ADUsers.ADUser", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("PermitRequestApp.Domain.CumulativeLeaveRequests.CumulativeLeaveRequest", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PermitRequestApp.Domain.LeaveRequests.LeaveRequest", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "AssignedUser")
                        .WithMany()
                        .HasForeignKey("AssignedUserId");

                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "RequestUser")
                        .WithMany()
                        .HasForeignKey("RequestUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedUser");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");

                    b.Navigation("RequestUser");
                });

            modelBuilder.Entity("PermitRequestApp.Domain.Notifications.Notification", b =>
                {
                    b.HasOne("PermitRequestApp.Domain.CumulativeLeaveRequests.CumulativeLeaveRequest", "CumulativeLeaveRequest")
                        .WithMany()
                        .HasForeignKey("CumulativeLeaveRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PermitRequestApp.Domain.ADUsers.ADUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CumulativeLeaveRequest");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
