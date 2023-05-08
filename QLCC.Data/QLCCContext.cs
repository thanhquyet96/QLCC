using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using QLCC.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace QLCC.Data
{
    public class QLCCContext:DbContext
    {
        private readonly string _connectionString;
        public QLCCContext()
        {
            var connectionString = "Server=localhost;Database=QLCC_V2;Trusted_Connection=false;User Id=sa;password=Ab@123456;TrustServerCertificate=true;";
            _connectionString = connectionString;
        }
        public QLCCContext(DbContextOptions<QLCCContext> options)
         : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)
            {
                options.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<USER>(entity =>
            {
                entity.HasKey(e => e.ID);
            });
            modelBuilder.Entity<USER_ROLE>(entity =>
            {
                entity.HasKey(e => new { e.ROLE_ID, e.USER_ID });
            });

            //modelBuilder.Entity<Book>(entity =>
            //{
            //    entity.HasKey(e => e.ISBN);
            //    entity.Property(e => e.Title).IsRequired();
            //    entity.HasOne(d => d.Publisher)
            //      .WithMany(p => p.Books);
            //});
        }

        public DbSet<DATE_TIME_KEEP> DATE_TIME_KEEPS { get; set; }
        public DbSet<HISTORY_TIME_KEEP> HISTORY_TIME_KEEPS { get; set; }
        public DbSet<LEAVE> LEAVES { get; set; }
        public DbSet<ROLE> ROLES { get; set; }
        public DbSet<TIME_KEEP> TIME_KEEPS { get; set; }
        public DbSet<USER> USERS { get; set; }
        public DbSet<USER_ROLE> USER_ROLES { get; set; }

    }
}

