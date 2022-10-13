using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PT1.Models
{
    public partial class PT11Context : DbContext
    {
        public PT11Context()
        {
        }

        public PT11Context(DbContextOptions<PT11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetType> AssetTypes { get; set; } = null!;
        public virtual DbSet<AssetTypeGroup> AssetTypeGroups { get; set; } = null!;
        public virtual DbSet<MaterialGroup> MaterialGroups { get; set; } = null!;
        public virtual DbSet<MaterialType> MaterialTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server = DESKTOP-MCMOCN4\\SQLEXPRESS;database = PT11;uid=sa;pwd=1001;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasIndex(e => e.AssetTypeCode, "UQ_AssetTypeCode")
                    .IsUnique();

                entity.Property(e => e.AssetTypeId).HasColumnName("AssetTypeID");

                entity.Property(e => e.AssetTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssetTypeGroupId).HasColumnName("AssetTypeGroupID");

                entity.Property(e => e.AssetTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<AssetTypeGroup>(entity =>
            {
                entity.Property(e => e.AssetTypeGroupId).HasColumnName("AssetTypeGroupID");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<MaterialGroup>(entity =>
            {
                entity.Property(e => e.MaterialGroupId).HasColumnName("MaterialGroupID");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<MaterialType>(entity =>
            {
                entity.HasIndex(e => e.MaterialTypeCode, "UQ_MaterialCode")
                    .IsUnique();

                entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

                entity.Property(e => e.MaterialGroupId).HasColumnName("MaterialGroupID");

                entity.Property(e => e.MaterialTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialTypeName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
