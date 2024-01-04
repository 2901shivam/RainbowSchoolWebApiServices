using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RainbowSchoolWebServiices.Models
{
    public partial class RanbowSchoolDbContext : DbContext
    {
        public RanbowSchoolDbContext()
        {
        }

        public RanbowSchoolDbContext(DbContextOptions<RanbowSchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=SHIVAMSINGH;database=RanbowSchoolDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Class__C1F8DC39B087D526");

                entity.ToTable("Class");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CId");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Customer__C1F8DC395E954C5F");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("CId");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("CName");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Odlimit).HasColumnName("ODLimit");

                entity.Property(e => e.Sdate)
                    .HasColumnType("date")
                    .HasColumnName("SDate");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StudentName).HasMaxLength(50);

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Class)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Student__Class__4E88ABD4");

                entity.HasOne(d => d.SubjectsNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Subjects)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Student__Subject__4F7CD00D");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("PK__Subjects__4D9BB84AB12C1AF6");

                entity.Property(e => e.SubId).ValueGeneratedNever();

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
