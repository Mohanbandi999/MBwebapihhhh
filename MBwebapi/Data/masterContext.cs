using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MBwebapi.Models;

namespace MBwebapi.Data
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; } = null!;
        public virtual DbSet<Sl> Sl { get; set; } = null!;
        public virtual DbSet<Students> Students { get; set; } = null!;
        public virtual DbSet<TestSl> TestSl { get; set; } = null!;

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__9725F2C6079016D4");

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustMobileNo).HasColumnName("custMobileNo");

                entity.Property(e => e.CustName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("custName");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SL");

                entity.Property(e => e.City)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Name)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.Studentid)
                    .HasName("PK__students__4D16D264AF972B1C");

                entity.ToTable("students");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Studentmobileno).HasColumnName("studentmobileno");

                entity.Property(e => e.Studentname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("studentname");
            });

            modelBuilder.Entity<TestSl>(entity =>
            {
                entity.ToTable("TestSL");

                entity.Property(e => e.City)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Name)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
