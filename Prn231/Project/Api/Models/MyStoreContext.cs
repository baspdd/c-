using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class MyStoreContext : DbContext
{
    public MyStoreContext()
    {
    }

    public MyStoreContext(DbContextOptions<MyStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamAnswer> ExamAnswers { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server = DESKTOP-D0J2I3U\\SQLEXPRESS;database = MyStore;uid=sa;pwd=1001;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.AccountId).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(20);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseName).HasMaxLength(50);
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.Property(e => e.AccountId).HasMaxLength(50);
            entity.Property(e => e.KeyId).HasMaxLength(50);
            entity.Property(e => e.Score).HasMaxLength(200);

            entity.HasOne(d => d.Account).WithMany(p => p.Exams)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exams__AccountId__300424B4");

            entity.HasOne(d => d.Key).WithMany(p => p.Exams)
                .HasForeignKey(d => d.KeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exams__KeyId__30F848ED");
        });

        modelBuilder.Entity<ExamAnswer>(entity =>
        {
            entity.HasKey(e => e.ExamAnswer1);

            entity.Property(e => e.ExamAnswer1).HasColumnName("ExamAnswer");
            entity.Property(e => e.RightRightAnswer).HasMaxLength(200);

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamAnswers)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamAnswe__ExamI__31EC6D26");
        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.Property(e => e.KeyId).HasMaxLength(50);

            entity.HasOne(d => d.Course).WithMany(p => p.Keys)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Keys__CourseId__2E1BDC42");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.Answer).HasMaxLength(1000);
            entity.Property(e => e.Content).HasMaxLength(200);
            entity.Property(e => e.KeyId).HasMaxLength(50);
            entity.Property(e => e.RightAnswer).HasMaxLength(200);

            entity.HasOne(d => d.Key).WithMany(p => p.Questions)
                .HasForeignKey(d => d.KeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Questions__KeyId__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
