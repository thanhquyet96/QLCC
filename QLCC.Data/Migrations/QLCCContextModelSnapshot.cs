﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLCC.Data;

#nullable disable

namespace QLCC.Data.Migrations
{
    [DbContext(typeof(QLCCContext))]
    partial class QLCCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLCC.Data.Entities.DATE_TIME_KEEP", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TIME_CHECK_IN")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TIME_CHECK_OUT")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("DATE_TIME_KEEP");
                });

            modelBuilder.Entity("QLCC.Data.Entities.HISTORY_TIME_KEEP", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DATE_TIME_KEEP")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TIME_TIME_KEEP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("USER_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("USER_ID");

                    b.ToTable("HISTORY_TIME_KEEP");
                });

            modelBuilder.Entity("QLCC.Data.Entities.LEAVE", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("APPROVE_USER_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CREATED_FOR_DAY")
                        .HasColumnType("datetime2");

                    b.Property<int>("LEAVE_FORM")
                        .HasColumnType("int");

                    b.Property<int>("LEAVE_STATUS")
                        .HasColumnType("int");

                    b.Property<int>("LEAVE_TYPE")
                        .HasColumnType("int");

                    b.Property<string>("REASON")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("USER_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("APPROVE_USER_ID");

                    b.HasIndex("USER_ID");

                    b.ToTable("LEAVE");
                });

            modelBuilder.Entity("QLCC.Data.Entities.ROLE", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ROLE");
                });

            modelBuilder.Entity("QLCC.Data.Entities.TIME_KEEP", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DATE_TIME_KEEP_ID")
                        .HasColumnType("int");

                    b.Property<int?>("USER_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DATE_TIME_KEEP_ID");

                    b.HasIndex("USER_ID");

                    b.ToTable("TIME_KEEP");
                });

            modelBuilder.Entity("QLCC.Data.Entities.USER", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BIRTH_DAY")
                        .HasColumnType("datetime2");

                    b.Property<double?>("COEFFICIENTS_SALARY")
                        .HasColumnType("float");

                    b.Property<string>("FULL_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NUMBER_OF_DAYS")
                        .HasColumnType("int");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PHONE_NUMBER")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SALARY")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("USER_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nvarchar(50)");

                    b.Property<int?>("VACATION_DAY")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("QLCC.Data.Entities.USER_ROLE", b =>
                {
                    b.Property<int?>("ROLE_ID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int?>("USER_ID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ROLE_ID", "USER_ID");

                    b.HasIndex("USER_ID");

                    b.ToTable("USER_ROLE");
                });

            modelBuilder.Entity("QLCC.Data.Entities.HISTORY_TIME_KEEP", b =>
                {
                    b.HasOne("QLCC.Data.Entities.USER", "USER")
                        .WithMany()
                        .HasForeignKey("USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("USER");
                });

            modelBuilder.Entity("QLCC.Data.Entities.LEAVE", b =>
                {
                    b.HasOne("QLCC.Data.Entities.USER", "APPROVE_USER")
                        .WithMany("LEAVES")
                        .HasForeignKey("APPROVE_USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCC.Data.Entities.USER", "USER")
                        .WithMany()
                        .HasForeignKey("USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("APPROVE_USER");

                    b.Navigation("USER");
                });

            modelBuilder.Entity("QLCC.Data.Entities.TIME_KEEP", b =>
                {
                    b.HasOne("QLCC.Data.Entities.DATE_TIME_KEEP", "DATE_TIME_KEEP")
                        .WithMany("TIME_KEEPS")
                        .HasForeignKey("DATE_TIME_KEEP_ID");

                    b.HasOne("QLCC.Data.Entities.USER", "USER")
                        .WithMany("TIME_KEEPS")
                        .HasForeignKey("USER_ID");

                    b.Navigation("DATE_TIME_KEEP");

                    b.Navigation("USER");
                });

            modelBuilder.Entity("QLCC.Data.Entities.USER_ROLE", b =>
                {
                    b.HasOne("QLCC.Data.Entities.ROLE", "ROLE")
                        .WithMany("USER_ROLES")
                        .HasForeignKey("ROLE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCC.Data.Entities.USER", "USER")
                        .WithMany("USER_ROLES")
                        .HasForeignKey("USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ROLE");

                    b.Navigation("USER");
                });

            modelBuilder.Entity("QLCC.Data.Entities.DATE_TIME_KEEP", b =>
                {
                    b.Navigation("TIME_KEEPS");
                });

            modelBuilder.Entity("QLCC.Data.Entities.ROLE", b =>
                {
                    b.Navigation("USER_ROLES");
                });

            modelBuilder.Entity("QLCC.Data.Entities.USER", b =>
                {
                    b.Navigation("LEAVES");

                    b.Navigation("TIME_KEEPS");

                    b.Navigation("USER_ROLES");
                });
#pragma warning restore 612, 618
        }
    }
}
