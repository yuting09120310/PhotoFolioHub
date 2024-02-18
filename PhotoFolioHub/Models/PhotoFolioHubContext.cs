using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhotoFolioHub.Models;

public partial class PhotoFolioHubContext : DbContext
{
    public PhotoFolioHubContext()
    {
    }

    public PhotoFolioHubContext(DbContextOptions<PhotoFolioHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AlbumPhoto> AlbumPhotos { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<MenuGroup> MenuGroups { get; set; }

    public virtual DbSet<MenuSub> MenuSubs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAlbum> UserAlbums { get; set; }

    public virtual DbSet<UserPhoto> UserPhotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.210;Database=PhotoFolioHub;User ID=sa;Password=Alex0310;Trusted_Connection=True;Integrated Security=False;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminNum);

            entity.ToTable("Admin");

            entity.Property(e => e.AdminAcc).HasMaxLength(50);
            entity.Property(e => e.AdminName).HasMaxLength(50);
            entity.Property(e => e.AdminPwd).HasMaxLength(50);
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Admin__UserID__4BAC3F29");
        });

        modelBuilder.Entity<AlbumPhoto>(entity =>
        {
            entity.HasKey(e => e.AlbumPhotoId).HasName("PK__AlbumPho__8407D82C49A811FE");

            entity.Property(e => e.AlbumPhotoId).HasColumnName("AlbumPhotoID");
            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

            entity.HasOne(d => d.Album).WithMany(p => p.AlbumPhotos)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK__AlbumPhot__Album__571DF1D5");

            entity.HasOne(d => d.Photo).WithMany(p => p.AlbumPhotos)
                .HasForeignKey(d => d.PhotoId)
                .HasConstraintName("FK__AlbumPhot__Photo__5812160E");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.BannerNum);

            entity.ToTable("Banner");

            entity.Property(e => e.BannerContxt).HasComment("");
            entity.Property(e => e.BannerOffTime).HasColumnType("datetime");
            entity.Property(e => e.BannerPutTime).HasColumnType("datetime");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.Lang).HasMaxLength(50);
        });

        modelBuilder.Entity<MenuGroup>(entity =>
        {
            entity.HasKey(e => e.MenuGroupNum);

            entity.ToTable("MenuGroup");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.MenuGroupIcon).HasMaxLength(50);
            entity.Property(e => e.MenuGroupId).HasMaxLength(100);
            entity.Property(e => e.MenuGroupInfo).HasMaxLength(100);
            entity.Property(e => e.MenuGroupName).HasMaxLength(100);
            entity.Property(e => e.MenuGroupSort).HasDefaultValueSql("((0))");
            entity.Property(e => e.MenuGroupUrl).HasMaxLength(100);
        });

        modelBuilder.Entity<MenuSub>(entity =>
        {
            entity.HasKey(e => e.MenuSubNum);

            entity.ToTable("MenuSub");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.MenuGroupId).HasMaxLength(50);
            entity.Property(e => e.MenuSubIcon).HasMaxLength(50);
            entity.Property(e => e.MenuSubId).HasMaxLength(50);
            entity.Property(e => e.MenuSubInfo).HasMaxLength(50);
            entity.Property(e => e.MenuSubName).HasMaxLength(50);
            entity.Property(e => e.MenuSubRole).HasMaxLength(50);
            entity.Property(e => e.MenuSubSort).HasDefaultValueSql("((0))");
            entity.Property(e => e.MenuSubUrl).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC886EB2ED");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserAlbum>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__UserAlbu__97B4BE178D5FC979");

            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.AlbumName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserAlbums)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserAlbum__UserI__534D60F1");
        });

        modelBuilder.Entity<UserPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__UserPhot__21B7B582E549E68E");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");
            entity.Property(e => e.UploadDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserPhotos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserPhoto__UserI__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
