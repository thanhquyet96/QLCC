using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QLCC.Entities;

namespace QLCC.Models
{
    public partial class DataContext: DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=103.124.92.157;Database=QLCC;Trusted_Connection=True;User Id=sa;password=Ab@123456");
            }
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserInfo>(entity =>
            //{
            //    entity.HasNoKey();
            //    entity.ToTable("UserInfo");
            //    entity.Property(e => e.UserId).HasColumnName("UserId");
            //    entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
            //    entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
            //    entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
            //    entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            //    entity.Property(e => e.CreatedDate).IsUnicode(false);
            //});

            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.ToTable("Employee");
            //    entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
            //    entity.Property(e => e.NationalIDNumber).HasMaxLength(15).IsUnicode(false);
            //    entity.Property(e => e.EmployeeName).HasMaxLength(100).IsUnicode(false);
            //    entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
            //    entity.Property(e => e.JobTitle).HasMaxLength(50).IsUnicode(false);
            //    entity.Property(e => e.BirthDate).IsUnicode(false);
            //    entity.Property(e => e.MaritalStatus).HasMaxLength(1).IsUnicode(false);
            //    entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false);
            //    entity.Property(e => e.HireDate).IsUnicode(false);
            //    entity.Property(e => e.VacationHours).IsUnicode(false);
            //    entity.Property(e => e.SickLeaveHours).IsUnicode(false);
            //    entity.Property(e => e.RowGuid).HasMaxLength(50).IsUnicode(false);
            //    entity.Property(e => e.ModifiedDate).IsUnicode(false);
            //});
            modelBuilder.Entity<NhanVien_Quyen>(entity => {
                //    entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.HasKey(table => new {
                    table.QuyenId,
                    table.NhanVienId
                });
            });
            OnModelCreatingPartial(modelBuilder);
        }

        internal IEnumerable<User> ToList()
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<QLCC.Entities.ChamCong> ChamCong { get; set; }

        public DbSet<QLCC.Entities.NgayChamCong> NgayChamCong { get; set; }

        public DbSet<QLCC.Entities.NghiPhep> NghiPhep { get; set; }

        public DbSet<QLCC.Entities.LichSuChamCong> LichSuChamCong { get; set; }

        public DbSet<QLCC.Entities.Quyen> Quyen { get; set; }

        public DbSet<QLCC.Entities.NhanVien_Quyen> NhanVien_Quyen { get; set; }
    }
}
