﻿using HR_Management.Model.App_Model;
using Microsoft.EntityFrameworkCore;

namespace API_Task.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceSummary> AttendanceSummaries { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Company relationships
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.ComId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Designations)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.ComId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Departments)
                .WithOne(d => d.Company)
                .HasForeignKey(d => d.ComId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Shifts)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.ComId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Shift)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Designation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DesigId)
                .OnDelete(DeleteBehavior.Restrict);

            // Attendance relationships
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Company)
                .WithMany()
                .HasForeignKey(a => a.ComId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmpId)
                .OnDelete(DeleteBehavior.Cascade);

            // AttendanceSummary relationships
            modelBuilder.Entity<AttendanceSummary>()
                .HasOne(a => a.Company)
                .WithMany()
                .HasForeignKey(a => a.ComId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AttendanceSummary>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.AttendanceSummaries)
                .HasForeignKey(a => a.EmpId)
                .OnDelete(DeleteBehavior.Cascade);

            // Salary relationships
            modelBuilder.Entity<Salary>()
                .HasOne(s => s.Company)
                .WithMany()
                .HasForeignKey(s => s.ComId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Salary>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.EmpId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    

}
  

}