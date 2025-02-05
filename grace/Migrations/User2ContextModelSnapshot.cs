﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using grace.Context;

#nullable disable

namespace grace.Migrations
{
    [DbContext(typeof(User2Context))]
    partial class User2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("grace.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Durationinminutes")
                        .HasColumnType("integer")
                        .HasColumnName("durationinminutes");

                    b.Property<DateOnly?>("Enddate")
                        .HasColumnType("date")
                        .HasColumnName("enddate");

                    b.Property<DateOnly>("Startdate")
                        .HasColumnType("date")
                        .HasColumnName("startdate");

                    b.Property<TimeOnly>("Starttime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("starttime");

                    b.Property<int>("Statusid")
                        .HasColumnType("integer")
                        .HasColumnName("statusid");

                    b.Property<int>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("order_pk");

                    b.HasIndex("Statusid");

                    b.HasIndex("Userid");

                    b.ToTable("order", "schemagrace");
                });

            modelBuilder.Entity("grace.Models.Orderservice", b =>
                {
                    b.Property<int>("Orderid")
                        .HasColumnType("integer")
                        .HasColumnName("orderid");

                    b.Property<int>("Serviceid")
                        .HasColumnType("integer")
                        .HasColumnName("serviceid");

                    b.HasIndex("Orderid");

                    b.HasIndex("Serviceid");

                    b.ToTable("orderservice", "schemagrace");
                });

            modelBuilder.Entity("grace.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("role_pk");

                    b.ToTable("role", "schemagrace");
                });

            modelBuilder.Entity("grace.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("character varying")
                        .HasColumnName("code");

                    b.Property<int>("Costperhour")
                        .HasColumnType("integer")
                        .HasColumnName("costperhour");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("service_pk");

                    b.ToTable("service", "schemagrace");
                });

            modelBuilder.Entity("grace.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("status_pk");

                    b.ToTable("status", "schemagrace");
                });

            modelBuilder.Entity("grace.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("character varying")
                        .HasColumnName("address");

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<int?>("Pasportnumber")
                        .HasColumnType("integer")
                        .HasColumnName("pasportnumber");

                    b.Property<int?>("Pasportseries")
                        .HasColumnType("integer")
                        .HasColumnName("pasportseries");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("password");

                    b.Property<string>("Patronimic")
                        .HasColumnType("character varying")
                        .HasColumnName("patronimic");

                    b.Property<int>("Roleid")
                        .HasColumnType("integer")
                        .HasColumnName("roleid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("user_pk");

                    b.HasIndex("Roleid");

                    b.HasIndex(new[] { "Code" }, "user_unique")
                        .IsUnique();

                    b.ToTable("user", "schemagrace");
                });

            modelBuilder.Entity("grace.Models.Order", b =>
                {
                    b.HasOne("grace.Models.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("Statusid")
                        .IsRequired()
                        .HasConstraintName("order_status_fk");

                    b.HasOne("grace.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("order_user_fk");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("grace.Models.Orderservice", b =>
                {
                    b.HasOne("grace.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Orderid")
                        .IsRequired()
                        .HasConstraintName("orderservice_order_fk");

                    b.HasOne("grace.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("Serviceid")
                        .IsRequired()
                        .HasConstraintName("orderservice_service_fk");

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("grace.Models.User", b =>
                {
                    b.HasOne("grace.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Roleid")
                        .IsRequired()
                        .HasConstraintName("user_role_fk");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("grace.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("grace.Models.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("grace.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
