using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PMQLSuperbrain_Core.Models;

public partial class SuperbrainDbContext : DbContext
{
    public SuperbrainDbContext()
    {
    }

    public SuperbrainDbContext(DbContextOptions<SuperbrainDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionCategory> PermissionCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SuperbrainDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Enable)
                .HasDefaultValue(1)
                .HasColumnName("enable");
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RNote)
                .HasMaxLength(500)
                .HasColumnName("R_note");
            entity.Property(e => e.Updatetime)
                .HasColumnType("datetime")
                .HasColumnName("updatetime");
            entity.Property(e => e.WNote)
                .HasMaxLength(500)
                .HasColumnName("W_note");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Permission)
                .HasForeignKey<Permission>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_Permission_Category");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_Permission_User");
        });

        modelBuilder.Entity<PermissionCategory>(entity =>
        {
            entity.ToTable("Permission_Category");

            entity.Property(e => e.Enable)
                .HasDefaultValue(1)
                .HasColumnName("enable");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Public).HasColumnName("public");
            entity.Property(e => e.Stt)
                .HasDefaultValue(0)
                .HasColumnName("stt");
            entity.Property(e => e.Updatetime)
                .HasColumnType("datetime")
                .HasColumnName("updatetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.ToTable("User_Permission");

            entity.Property(e => e.Idcreate).HasColumnName("idcreate");
            entity.Property(e => e.Idtemplate).HasColumnName("idtemplate");
            entity.Property(e => e.Lever)
                .HasDefaultValue(0)
                .HasColumnName("lever");
            entity.Property(e => e.PerA)
                .HasDefaultValue(0)
                .HasColumnName("per_a");
            entity.Property(e => e.PerE)
                .HasDefaultValue(0)
                .HasColumnName("per_e");
            entity.Property(e => e.PerR)
                .HasDefaultValue(0)
                .HasColumnName("per_r");
            entity.Property(e => e.PerW)
                .HasDefaultValue(0)
                .HasColumnName("per_w");
            entity.Property(e => e.Permision)
                .HasDefaultValue(0)
                .HasColumnName("permision");
            entity.Property(e => e.Updatetime)
                .HasColumnType("datetime")
                .HasColumnName("updatetime");

            entity.HasOne(d => d.IdpermissionNavigation).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.Idpermission)
                .HasConstraintName("FK_User_Permission_Permission");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_User_Permission_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
