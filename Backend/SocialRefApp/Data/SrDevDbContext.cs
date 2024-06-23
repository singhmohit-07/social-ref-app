using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialRefApp.Entities;

namespace SocialRefApp.Data;

public partial class SrDevDbContext : DbContext
{
    public SrDevDbContext() { }

    public SrDevDbContext(DbContextOptions<SrDevDbContext> options)
        : base(options) { }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

        // modelBuilder.Entity<UserProfile>(entity =>
        // {
        //     entity.HasKey(e => e.ProfileId).HasName("PK__tmp_ms_x__290C88E4AA60FF62");

        //     entity.Property(e => e.IsActive).HasDefaultValue(true);
        //     entity.Property(e => e.Location).HasMaxLength(100).IsUnicode(false);
        //     entity.Property(e => e.ProfileCreatedDate).HasColumnType("datetime");
        //     entity.Property(e => e.ProfileDeactivationDate).HasColumnType("datetime");
        //     entity.Property(e => e.ProfileDescription).HasMaxLength(500).IsUnicode(false);
        //     entity.Property(e => e.ProfileHandle).HasMaxLength(100).IsUnicode(false);
        //     entity.Property(e => e.ProfileModifiedDate).HasColumnType("datetime");
        //     // entity.Property(e => e.UserId).HasMaxLength(450);
        //     entity
        //         .HasOne(e=> e.UserId)
        //         .WithOne()
        //         .HasForeignKey<User>(e => e.Id)
        //         .IsRequired(true);
        // });

 modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__tmp_ms_x__290C88E4AA60FF62");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.ProfileCreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ProfileDeactivationDate).HasColumnType("datetime");
            entity.Property(e => e.ProfileDescription).HasMaxLength(500);
            entity.Property(e => e.ProfileHandle).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.ProfileModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(450).IsRequired(true);
            // entity
            //     .HasOne(e => e.UserId)
            //     .WithOne()
            //     .HasForeignKey<User>(e => e.Id)
            //     .IsRequired(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
