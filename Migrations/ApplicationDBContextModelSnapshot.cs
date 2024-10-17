﻿// <auto-generated />
using System;
using API_Task.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hr_task.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HR_Management.Model.App_Model.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ComId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DtDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmpId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("InTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("OutTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ComId");

                    b.HasIndex("EmpId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.AttendanceSummary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Absent")
                        .HasColumnType("int");

                    b.Property<Guid>("ComId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DtMonth")
                        .HasColumnType("int");

                    b.Property<int>("DtYear")
                        .HasColumnType("int");

                    b.Property<Guid>("EmpId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Late")
                        .HasColumnType("int");

                    b.Property<int>("Present")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComId");

                    b.HasIndex("EmpId");

                    b.ToTable("AttendanceSummaries");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Company", b =>
                {
                    b.Property<Guid>("ComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Basic")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ComName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Hrent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Medical")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ComId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Department", b =>
                {
                    b.Property<Guid>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.HasIndex("ComId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Designation", b =>
                {
                    b.Property<Guid>("DesigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DesigName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesigId");

                    b.HasIndex("ComId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Employee", b =>
                {
                    b.Property<Guid>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Basic")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ComId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DesigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DtJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmpCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Gross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HRent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Medical")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Others")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ShiftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("desigName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shiftName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.HasIndex("ComId");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesigId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AbsentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Basic")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ComId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DtMonth")
                        .HasColumnType("int");

                    b.Property<int>("DtYear")
                        .HasColumnType("int");

                    b.Property<Guid>("EmpId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hrent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<decimal>("Medical")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PayableAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ComId");

                    b.HasIndex("EmpId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Shift", b =>
                {
                    b.Property<Guid>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Late")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("empIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("empOut")
                        .HasColumnType("datetime2");

                    b.HasKey("ShiftId");

                    b.HasIndex("ComId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Attendance", b =>
                {
                    b.HasOne("HR_Management.Model.App_Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HR_Management.Model.App_Model.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.AttendanceSummary", b =>
                {
                    b.HasOne("HR_Management.Model.App_Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HR_Management.Model.App_Model.Employee", "Employee")
                        .WithMany("AttendanceSummaries")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Department", b =>
                {
                    b.HasOne("HR_Management.Model.App_Model.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Designation", b =>
                {
                    b.HasOne("HR_Management.Model.App_Model.Company", "Company")
                        .WithMany("Designations")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Employee", b =>
                {
                    b.HasOne("HR_Management.Model.App_Model.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HR_Management.Model.App_Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HR_Management.Model.App_Model.Designation", "Designation")
                        .WithMany("Employees")
                        .HasForeignKey("DesigId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HR_Management.Model.App_Model.Shift", "Shift")
                        .WithMany("Employees")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Designation");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Salary", b =>
                {
                    b.HasOne("HR_Management.Model.App_Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HR_Management.Model.App_Model.Employee", "Employee")
                        .WithMany("Salaries")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Shift", b =>
                {
                    b.HasOne("HR_Management.Model.App_Model.Company", "Company")
                        .WithMany("Shifts")
                        .HasForeignKey("ComId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Designations");

                    b.Navigation("Employees");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Designation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Employee", b =>
                {
                    b.Navigation("AttendanceSummaries");

                    b.Navigation("Attendances");

                    b.Navigation("Salaries");
                });

            modelBuilder.Entity("HR_Management.Model.App_Model.Shift", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
